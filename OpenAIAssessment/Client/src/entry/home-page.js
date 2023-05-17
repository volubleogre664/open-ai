import { createApp, h } from "vue";
import wrapper from "vue3-webcomponent-wrapper";
import Page from "../pages/home-page.vue";
window.customElements.define('home-page', wrapper(Page, createApp, h));