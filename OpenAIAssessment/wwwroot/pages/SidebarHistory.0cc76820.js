import{d as n,r as a,o as t,c as r,a as c,F as i,e as l,f as p,_ as d}from"./_plugin-vue_export-helper.34eb5909.js";import{C as m}from"./HistoryItem.1f2f3248.js";const u=n({name:"SidebarHistory",components:{HistoryItem:m},props:{historyItems:{type:Array,required:!0},newChatClick:{type:Function,required:!0}},data(){return{}},methods:{startNewChat(){console.log("New Chat")}}}),C={class:"history"};function y(s,_,h,k,f,I){const o=a("HistoryItem");return t(),r("div",C,[c(o,{text:"New Chat",click:s.newChatClick,"styling-mode":"outlined",isNewChat:!0},null,8,["click"]),(t(!0),r(i,null,l(s.historyItems,e=>(t(),p(o,{key:e.HistoryId,text:e.Content,click:e.Click},null,8,["text","click"]))),128))])}const A=d(u,[["render",y],["__file","C:/Users/nduduzos/source/repos/OpenAIAssessment/OpenAIAssessment/Client/src/components/SidebarHistory.vue"]]);export{A as S};
