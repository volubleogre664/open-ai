<template>
    <div class="textEditor">
        <SidebarHistory
            :history-items="history"
            :new-chat-click="newEditClick"
        />

        <main class="textEditor-body">
            <section class="textEditor-bodyMain">
                <div class="text-container old-text">
                    <DxScrollView width="100%" height="100%">
                        <DxTextArea
                            width="100%"
                            height="100%"
                            :value="text.OldText"
                            placeholder="Type your text here..."
                        />
                    </DxScrollView>
                </div>

                <div class="text-container new-text">
                    <DxScrollView width="100%" height="100%">
                        <DxTextArea
                            max-hight="100%"
                            :auto-resize-enabled="true"
                            width="100%"
                            :read-only="true"
                            :value="text.NewText"
                            placeholder="Edited text will show here..."
                        />
                    </DxScrollView>
                </div>
            </section>

            <footer class="textEditor-bodyFooter">
                <DxButton
                    text="Fix Spelling"
                    styling-mode="contained"
                    type="default"
                    width="70%"
                    :onClick="getSpellingClick"
                />

                <DxButton
                    text="Fix Grammar"
                    styling-mode="contained"
                    type="default"
                    width="70%"
                    :onClick="getGrammarClick"
                />

                <DxButton
                    text="Fix Spelling and Grammar"
                    styling-mode="contained"
                    type="default"
                    width="70%"
                    :onClick="getSpellingAndGrammarClick"
                />
            </footer>
        </main>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import SidebarHistory from "../components/SidebarHistory.vue";
import { DxTextArea, DxButton, DxScrollView } from "devextreme-vue";
import { createStore } from "devextreme-aspnet-data-nojquery";

const textUrl = "/TextEditorWebAPI/";
const historyUrl = "/HistoryWebAPI/";

type Text = {
    TextId: number;
    OldText: string;
    NewText: string;
    HistoryId: number;
};

type History = {
    HistoryId: number;
    Content: string;
    Click: () => void;
};

type Data = {
    text: Text;
    history: History[];
    currentEditor: History;
};

type TextResponse = {
    TextId: number;
    Text: string;
    IsBot: boolean;
    HistoryId: number;
};

const textStore = createStore({
    key: "TextId",
    loadUrl: textUrl + "Get/",
    insertUrl: textUrl + "Post/",
    loadMethod: "GET",
    insertMethod: "POST",
});

const historyStore = createStore({
    key: "HistoryId",
    loadUrl: historyUrl + "Get/",
    loadMethod: "GET",
    loadParams: { page: "texteditor" },
    onBeforeSend: function (method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
    },
});

export default defineComponent({
    name: "text-editor-page",

    props: {},

    components: { SidebarHistory, DxTextArea, DxButton, DxScrollView },

    data(): Data {
        return {
            history: [],
            currentEditor: {
                HistoryId: 0,
                Content: "",
                Click: () => {},
            },
            text: {
                TextId: 0,
                OldText: "",
                NewText: "",
                HistoryId: 0,
            },
        };
    },

    mounted() {
        this.getHistory();
    },

    methods: {
        sendMessage(instruction: string) {
            var input = document.querySelector(
                "textarea:first-of-type"
            ) as HTMLInputElement;
            var message = input.value;

            textStore
                .insert({ instruction, message })
                .then((data: TextResponse[]) => {
                    console.log("Text", data);
                    let textItem: Text = {
                        TextId: data[0].TextId,
                        OldText: "",
                        NewText: "",
                        HistoryId: data[0].HistoryId,
                    };

                    data.forEach((item) => {
                        if (item.IsBot) {
                            textItem.NewText = item.Text;
                        } else {
                            textItem.OldText = item.Text;
                        }
                        return textItem;
                    });

                    this.history.push({
                        HistoryId: textItem.HistoryId,
                        Content: textItem.OldText,
                        Click: () => {
                            this.getEditsForHistory(textItem.HistoryId);
                            this.currentEditor = {
                                HistoryId: textItem.HistoryId,
                                Content: textItem.OldText,
                                Click: () => {},
                            };
                        },
                    });

                    this.text = textItem;
                });
        },

        getSpellingClick() {
            this.sendMessage("Fix the Spelling");
        },

        getGrammarClick() {
            this.sendMessage("Fix the Grammar");
        },

        getSpellingAndGrammarClick() {
            this.sendMessage("Fix the Spelling and Grammar");
        },

        newEditClick() {
            this.currentEditor = {
                HistoryId: 0,
                Content: "",
                Click: () => {},
            };

            this.text = {
                TextId: 0,
                OldText: "",
                NewText: "",
                HistoryId: 0,
            };
        },

        getEditsForHistory(historyId: number) {
            var url = textUrl + "Get/?historyId=" + historyId;

            fetch(url)
                .then((response) => response.json())
                .then(({ data }) => {
                    console.log("Text", data);
                    let textItem: Text = {
                        TextId: data[0].TextId,
                        OldText: "",
                        NewText: "",
                        HistoryId: data[0].HistoryId,
                    };

                    data.forEach((item: TextResponse) => {
                        if (item.IsBot) {
                            textItem.NewText = item.Text;
                        } else {
                            textItem.OldText = item.Text;
                        }
                        return textItem;
                    });

                    this.text = textItem;
                });
        },

        getHistory(): void {
            historyStore.load().then((data: History[]) => {
                let result = data.map((item) => {
                    let historyItem: History = {
                        HistoryId: item.HistoryId,
                        Content: item.Content,
                        Click: () => {
                            this.getEditsForHistory(item.HistoryId);
                            this.currentEditor = {
                                HistoryId: item.HistoryId,
                                Content: item.Content,
                                Click: () => {},
                            };
                        },
                    };

                    return historyItem;
                });

                this.history = result;
            });
        },
    },
});
</script>
