import { defineCustomElement } from "vue";
import Component from "../components/ChatItem.vue";
window.customElements.define('ChatItem', defineCustomElement(Component));