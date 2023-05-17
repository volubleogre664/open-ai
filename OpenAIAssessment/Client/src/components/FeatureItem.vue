<template>
    <div class="feature">
        <div class="feature-content">
            <h3>{{ title }}</h3>
            <p>
                {{ description }}
            </p>

            <DxButton
                text="Continue"
                type="default"
                stylingMode="contained"
                :onClick="onClick"
            />
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

import { DxButton } from "devextreme-vue";

export default defineComponent({
    name: "FeatureItem",

    props: {
        title: {
            type: String,
            required: true,
        },

        description: {
            type: String,
            required: true,
        },

        url: {
            type: String,
            required: true,
        },
    },

    components: {
        DxButton,
    },

    data() {
        return {};
    },

    methods: {
        onClick() {
            window.open(this.url);
        },
    },
});
</script>
