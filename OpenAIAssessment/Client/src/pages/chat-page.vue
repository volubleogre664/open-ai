<template>
    <div class="chat">
        <SidebarHistory />

        <main class="chat-body">
            <div class="chat-bodyMain">
                <DxTextArea
                    :read-only="true"
                    :max-hight="textAreaMaxHeight"
                    :min-height="textAreaMaxHeight"
                />
            </div>

            <footer class="chat-bodyFooter">
                <DxTextArea
                    :max-hight="300"
                    :auto-resize-enabled="true"
                    width="100%"
                    :value="message"
                    placeholder="Type a message..."
                />

                <DxButton
                    :width="50"
                    :height="50"
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
import SidebarHistory from "../components/SidebarHistory.vue";

export default defineComponent({
    name: "chat-page",

    props: {},

    components: { SidebarHistory, DxTextArea, DxButton },

    data() {
        return {
            message: "",
            textAreaMaxHeight: "100%",
        };
    },

    methods: {
        sendMessage() {
            console.log(this.message);
        },
    },
});
</script>
