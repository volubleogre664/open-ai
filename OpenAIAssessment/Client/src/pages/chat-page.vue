<template>
    <div class="chat">
        <SidebarHistory />

        <main class="chat-body">
            <div class="chat-bodyMain">
                <ChatItem
                    v-for="item in chatItems"
                    :message="item.message"
                    :isMine="item.isMine"
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
import ChatItem from "../components/ChatItem.vue";

export default defineComponent({
    name: "chat-page",

    props: {},

    components: { SidebarHistory, ChatItem, DxButton, DxTextArea },

    data() {
        return {
            message: "",
            textAreaMaxHeight: "100%",
            chatItems: [
                {
                    message: "Hello",
                    isMine: true,
                },
                {
                    message: "Hi",
                    isMine: false,
                },
                {
                    message: "How are you?",
                    isMine: true,
                },
                {
                    message: "Fine, thanks",
                    isMine: false,
                },
                {
                    message: "And you?",
                    isMine: false,
                },
                {
                    message: "I'm fine too",
                    isMine: true,
                },
                {
                    message: "What are you doing?",
                    isMine: true,
                },
                {
                    message: "Hello",
                    isMine: true,
                },
                {
                    message: "Hi",
                    isMine: false,
                },
                {
                    message: "How are you?",
                    isMine: true,
                },
                {
                    message: "Fine, thanks",
                    isMine: false,
                },
                {
                    message: "And you?",
                    isMine: false,
                },
                {
                    message: "I'm fine too",
                    isMine: true,
                },
                {
                    message: "What are you doing?",
                    isMine: true,
                },
            ],
        };
    },

    methods: {
        sendMessage() {
            console.log(this.message);
        },
    },
});
</script>
