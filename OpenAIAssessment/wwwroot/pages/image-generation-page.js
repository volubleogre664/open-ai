import{d,r as e,o as t,c as r,a as o,b as a,F as u,e as g,f as _,_ as h,g as x,h as f}from"./_plugin-vue_export-helper.34eb5909.js";import{w as b}from"./index.832b91df.js";import{d as p}from"./index.bfe2db98.js";import{S as y}from"./SidebarHistory.3ecd085c.js";import{C as A}from"./ImageResult.b3f9fef1.js";import"./HistoryItem.18a3e533.js";const D=d({name:"image-generation-page",props:{},components:{SidebarHistory:y,ImageResult:A,DxTextArea:p.DxTextArea,DxButton:p.DxButton},data(){return{message:"",imageResults:[{prompt:"A dog",result:"https://images.pexels.com/photos/1851164/pexels-photo-1851164.jpeg?auto=compress&cs=tinysrgb&w=600"},{prompt:"A cat",result:"https://media.istockphoto.com/id/1417545154/photo/a-cute-cat-is-playing.jpg?b=1&s=612x612&w=0&k=20&c=6dBMxNNrGDef-eKK7NN0wr74su2uj3PLqPDHo5r1RL8="},{prompt:"A bird",result:"https://images.pexels.com/photos/17811/pexels-photo.jpg?auto=compress&cs=tinysrgb&w=600"}]}},methods:{sendMessage(){console.log(this.message)}}}),w={class:"imageGen"},B={class:"imageGen-body"},C={class:"imageGen-bodyMain"},k={class:"imageGen-bodyFooter"};function v(s,R,G,I,S,T){const m=e("SidebarHistory"),i=e("ImageResult"),c=e("DxTextArea"),l=e("DxButton");return t(),r("div",w,[o(m),a("main",B,[a("section",C,[(t(!0),r(u,null,g(s.imageResults,n=>(t(),_(i,{prompt:n.prompt,result:n.result},null,8,["prompt","result"]))),256))]),a("footer",k,[o(c,{"max-hight":300,"auto-resize-enabled":!0,width:"100%",value:s.message,placeholder:"Type a message..."},null,8,["value"]),o(l,{text:"Send","styling-mode":"contained",type:"default",onClick:s.sendMessage},null,8,["onClick"])])])])}const N=h(D,[["render",v],["__file","C:/Users/nduduzos/source/repos/OpenAIAssessment/OpenAIAssessment/Client/src/pages/image-generation-page.vue"]]);window.customElements.define("image-generation-page",b(N,x,f));
