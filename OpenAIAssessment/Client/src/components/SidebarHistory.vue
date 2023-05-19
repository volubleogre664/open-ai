<template>
    <div class="history">
        <HistoryItem
            text="New Chat"
            :click="newChatClick"
            styling-mode="outlined"
            :isNewChat="true"
        />

        <HistoryItem
            v-for="item in historyItems"
            :key="item.HistoryId"
            :text="item.Content"
            :click="item.Click"
        />
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import HistoryItem from "./HistoryItem.vue";

type ChatHistory = {
    HistoryId: number;
    Content: string;
    Click: () => void;
};

type Data = {};

export default defineComponent({
    name: "SidebarHistory",

    components: { HistoryItem },

    props: {
        historyItems: {
            type: Array<ChatHistory>,
            required: true,
        },

        newChatClick: {
            type: Function,
            required: true,
        },
    },

    data(): Data {
        return {};
    },

    methods: {
        startNewChat() {
            console.log("New Chat");
        },
    },
});
</script>
