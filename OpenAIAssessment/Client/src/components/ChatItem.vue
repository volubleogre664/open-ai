<template>
    <div>
        <div class="chat-item" :class="isBot ? 'not-mine' : 'mine'">
            <div class="chat-itemContent">
                <p class="chat-itemContentMessage">{{ message }}</p>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
    name: "ChatItem",

    props: {
        message: {
            type: String,
            required: true,
        },

        isBot: {
            type: Boolean,
            required: true,
        },
    },

    components: {},

    data() {
        return {};
    },

    methods: {},
});
</script>
