import { defineCustomElement } from "vue";
import Component from "../components/history-item.vue";
window.customElements.define('history-item', defineCustomElement(Component));