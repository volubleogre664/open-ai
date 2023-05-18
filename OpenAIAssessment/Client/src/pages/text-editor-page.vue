<template>
    <div class="textEditor">
        <SidebarHistory />

        <main class="textEditor-body">
            <section class="textEditor-bodyMain">
                <div class="text-container old-text">
                    <DxScrollView width="100%" height="100%">
                        <DxTextArea
                            width="100%"
                            height="100%"
                            :value="oldText"
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
                            :value="newText"
                            placeholder="Edited text will show here..."
                        />
                    </DxScrollView>
                </div>
            </section>

            <footer class="textEditor-bodyFooter">
                <DxButton
                    text="Make Corrections"
                    styling-mode="contained"
                    type="default"
                    width="70%"
                    :onClick="sendMessage"
                />
            </footer>
        </main>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import SidebarHistory from "../components/SidebarHistory.vue";
import { DxTextArea, DxButton, DxScrollView } from "devextreme-vue";

export default defineComponent({
    name: "text-editor-page",

    props: {},

    components: { SidebarHistory, DxTextArea, DxButton, DxScrollView },

    data() {
        return {
            oldText:
                "Lorem ipsum dolor sit amet consectetur adipisicing elit. Error dolor eligendi obcaecati, exercitationem necessitatibus animi sed ad voluptate culpa. Odit perspiciatis sunt rerum autem nemo repudiandae corrupti vero nobis beatae!",
            newText:
                "Lorem ipsum dolor sit amet consectetur adipisicing elit. Error dolor eligendi obcaecati, exercitationem necessitatibus animi sed ad voluptate culpa. Odit perspiciatis sunt rerum autem nemo repudiandae corrupti vero nobis beatae!",
        };
    },

    methods: {
        sendMessage() {
            console.log("send message");
        },
    },
});
</script>
