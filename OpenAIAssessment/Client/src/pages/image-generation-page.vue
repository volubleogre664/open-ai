<template>
    <div class="imageGen">
        <SidebarHistory />

        <main class="imageGen-body">
            <section class="imageGen-bodyMain">
                <ImageResult
                    v-for="item in imageResults"
                    :prompt="item.prompt"
                    :result="item.result"
                />
            </section>

            <footer class="imageGen-bodyFooter">
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
import ImageResult from "../components/ImageResult.vue";

export default defineComponent({
    name: "image-generation-page",

    props: {},

    components: { SidebarHistory, ImageResult, DxTextArea, DxButton },

    data() {
        return {
            message: "",
            imageResults: [
                {
                    prompt: "A dog",
                    result: "https://images.pexels.com/photos/1851164/pexels-photo-1851164.jpeg?auto=compress&cs=tinysrgb&w=600",
                },
                {
                    prompt: "A cat",
                    result: "https://media.istockphoto.com/id/1417545154/photo/a-cute-cat-is-playing.jpg?b=1&s=612x612&w=0&k=20&c=6dBMxNNrGDef-eKK7NN0wr74su2uj3PLqPDHo5r1RL8=",
                },
                {
                    prompt: "A bird",
                    result: "https://images.pexels.com/photos/17811/pexels-photo.jpg?auto=compress&cs=tinysrgb&w=600",
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
