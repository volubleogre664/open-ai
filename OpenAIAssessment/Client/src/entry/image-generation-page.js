import { createApp, h } from "vue";
import wrapper from "vue3-webcomponent-wrapper";
import Page from "../pages/image-generation-page.vue";
window.customElements.define('image-generation-page', wrapper(Page, createApp, h));