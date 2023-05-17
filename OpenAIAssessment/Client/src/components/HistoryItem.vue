<template>
    <DxButton
        :width="width"
        :text="text"
        type="normal"
        :styling-mode="stylingMode"
        :onClick="click"
    />
</template>

<script lang="ts">
import { DxButton } from "devextreme-vue";
import { defineComponent } from "vue";

export default defineComponent({
    name: "HistoryItem",

    props: {
        text: {
            type: String,
            required: true,
        },

        stylingMode: {
            type: String,
            default: "text",
        },

        click: {
            type: Function,
            required: true,
        },
    },

    components: { DxButton },

    data() {
        return {
            width: "100%",
        };
    },

    methods: {},
});
</script>
