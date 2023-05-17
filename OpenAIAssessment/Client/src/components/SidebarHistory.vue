<template>
    <div class="history">
        <HistoryItem
            :text="newChat"
            :click="startNewChat"
            :styling-mode="styleMode"
        />

        <HistoryItem
            v-for="item in historyItems"
            :key="item.text"
            :text="item.text"
            :click="item.click"
        />
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import HistoryItem from "./HistoryItem.vue";

export default defineComponent({
    name: "SidebarHistory",

    components: { HistoryItem },

    data() {
        return {
            newChat: "New Chat",
            styleMode: "outlined",
            historyItems: [
                {
                    text: "Chat 1",
                    click: () => {
                        console.log("Chat 1");
                    },
                },
                {
                    text: "Chat 2",
                    click: () => {
                        console.log("Chat 2");
                    },
                },
                {
                    text: "Chat 3",
                    click: () => {
                        console.log("Chat 3");
                    },
                },
            ],
        };
    },

    methods: {
        startNewChat() {
            console.log("New Chat");
        },
    },
});
</script>
