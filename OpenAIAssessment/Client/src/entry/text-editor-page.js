import { createApp, h } from "vue";
import wrapper from "vue3-webcomponent-wrapper";
import Page from "../pages/text-editor-page.vue";
window.customElements.define('text-editor-page', wrapper(Page, createApp, h));