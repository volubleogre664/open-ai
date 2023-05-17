<template>
    <div class="feature">
        <h3>Chat</h3>
        <p>Let AI help you with any burning question you might have.</p>
        
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: "history-item",

        props: {
            heading: String,
            text: String,
            url: String,
        },

        components: {},

        data() {
            return {};
        },

        methods: {}
    })
</script>