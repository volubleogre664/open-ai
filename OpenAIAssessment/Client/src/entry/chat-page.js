import { createApp, h } from "vue";
import wrapper from "vue3-webcomponent-wrapper";
import Page from "../pages/chat-page.vue";
window.customElements.define('chat-page', wrapper(Page, createApp, h));