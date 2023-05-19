<template>
    <div class="chat">
        <SidebarHistory
            :newChatClick="newChatClicked"
            :historyItems="history"
        />

        <main class="chat-body">
            <div class="chat-bodyMain">
                <ChatItem
                    v-for="item in chatItems"
                    :message="item.Content"
                    :isBot="item.IsBot"
                />
            </div>

            <footer class="chat-bodyFooter">
                <DxTextArea
                    :max-hight="300"
                    :auto-resize-enabled="true"
                    width="100%"
                    placeholder="Type a message..."
                />

                <DxButton
                    text="Send"
                    styling-mode="contained"
                    type="default"
                    :onClick="sendMessage"
                />
            </footer>
        </main>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { DxTextArea, DxButton } from "devextreme-vue";
import { createStore } from "devextreme-aspnet-data-nojquery";
import SidebarHistory from "../components/SidebarHistory.vue";
import ChatItem from "../components/ChatItem.vue";

type Chat = {
    Content: string;
    IsBot: boolean;
    HistoryId: number;
    ChatId: number;
};

type History = {
    HistoryId: number;
    Content: string;
    Click: () => void;
};

type Data = {
    message: string;
    textAreaMaxHeight: string;
    chatItems: Chat[];
    isNewChat: boolean;
    history: History[];
    currentChat: History;
};

const chatUrl = "/ChatWebAPI/";
const historyUrl = "/HistoryWebAPI/";

const chatStore = createStore({
    key: "message",
    loadUrl: chatUrl + "Get/",
    insertUrl: chatUrl + "Post/",
    insertMethod: "POST",
    loadMethod: "GET",
    onBeforeSend: function (method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
    },
});

const historyStore = createStore({
    key: "HistoryId",
    loadUrl: historyUrl + "Get/",
    loadMethod: "GET",
    loadParams: { page: "chat" },
    onBeforeSend: function (method, ajaxOptions) {
        ajaxOptions.xhrFields = { withCredentials: true };
    },
});

export default defineComponent({
    name: "chat-page",

    props: {},

    components: { SidebarHistory, ChatItem, DxButton, DxTextArea },

    data(): Data {
        return {
            message: "",
            textAreaMaxHeight: "100%",
            chatItems: [],
            isNewChat: true,
            history: [],
            currentChat: {
                HistoryId: 0,
                Content: "",
                Click: () => {},
            },
        };
    },

    mounted() {
        this.getHistory();
    },

    methods: {
        sendMessage(): void {
            let input = document.querySelector(
                ".dx-texteditor-input"
            ) as HTMLTextAreaElement;

            this.message = input.value;

            console.log("History Items: ", this.history);
            console.log("Current Chat: ", this.currentChat);

            chatStore
                .insert({
                    historyId: this.currentChat.HistoryId,
                    message: this.message,
                    isNewChat: this.isNewChat,
                })
                .then((data: Chat[]) => {
                    this.chatItems.push(...data);

                    let chatsDiv = document.querySelector(
                        ".chat-bodyMain"
                    ) as HTMLDivElement;
                    chatsDiv.scrollTop = chatsDiv.scrollHeight;

                    if (!(this.isNewChat && data.length > 0)) {
                        return;
                    }

                    this.isNewChat = false;
                    this.currentChat = {
                        HistoryId: data[0].HistoryId,
                        Content: data[0].Content,
                        Click: () => {
                            this.isNewChat = false;
                            this.getChatsForHistory(data[0].HistoryId);
                            this.currentChat = {
                                HistoryId: data[0].HistoryId,
                                Content: data[0].Content,
                                Click: () => {},
                            };
                        },
                    };

                    this.history.push(this.currentChat);
                });

            input.value = "";
            this.message = "";
        },

        newChatClicked(): void {
            this.isNewChat = true;
            this.currentChat = {
                HistoryId: 0,
                Content: "",
                Click: () => {},
            };

            this.chatItems = [];
        },

        getHistory(): void {
            historyStore.load().then((data: History[]) => {
                console.log("History: ", data);
                let result = data.map((item) => {
                    let historyItem: History = {
                        HistoryId: item.HistoryId,
                        Content: item.Content,
                        Click: () => {
                            this.getChatsForHistory(item.HistoryId);
                            this.isNewChat = false;
                            this.currentChat = {
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

        getChatsForHistory(historyId: number): void {
            let url = `${chatUrl}Get?historyId=${historyId}&isNewChat=false`;

            fetch(url)
                .then((response) => response.json())
                .then(({ data }) => {
                    this.chatItems = data;
                });
        },
    },
});
</script>
