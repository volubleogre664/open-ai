<template>
    <div class="imageGen-result">
        <div class="imageGen-resultPrompt">{{ prompt }}</div>

        <div class="imageGen-resultImage">
            <img :src="result" />
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
    name: "image-result",

    props: {
        prompt: {
            type: String,
            required: true,
        },

        result: {
            type: String,
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
