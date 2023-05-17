<template>
    <header class="home-header">
        <h1>Your everyday AI Partner</h1>
        <p>
            Get the best help from your AI companion. Regular research, text
            editing or image generation, we've got you covered.
        </p>
    </header>

    <main>
        <div class="features">
            <FeatureItem
                title="Chat"
                description="Chat with your AI companion. Any burning questions you have, it will answer them for you."
                url="/Chat"
            />

            <FeatureItem
                title="Text Editing"
                description="Edit your text with the help of your AI companion. Spelling check, grammar check, and many more."
                url="/TextEditor"
            />

            <FeatureItem
                title="Image Generation"
                description="Generate images with the help of your AI companion. Simply describe your want and it will generate it for you."
                url="/ImageGeneration"
            />
        </div>
    </main>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import FeatureItem from "../components/FeatureItem.vue";

export default defineComponent({
    name: "home-page",

    props: {},

    components: {
        FeatureItem,
    },

    data() {
        return {};
    },

    methods: {},
});
</script>
