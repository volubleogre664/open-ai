import { defineCustomElement } from "vue";
import Component from "../components/FeatureItem.vue";
window.customElements.define('FeatureItem', defineCustomElement(Component));