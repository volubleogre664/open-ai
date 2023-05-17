import { defineCustomElement } from "vue";
import Component from "../components/HistoryItem.vue";
window.customElements.define('HistoryItem', defineCustomElement(Component));