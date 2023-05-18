import{h as Y,b as tt}from"./index.573f11c0.js";var $={exports:{}};(function(q,et){(function(m,p){q.exports=p()})(typeof self<"u"?self:Y,function(){return function(m){var p={};function u(o){if(p[o])return p[o].exports;var i=p[o]={i:o,l:!1,exports:{}};return m[o].call(i.exports,i,i.exports,u),i.l=!0,i.exports}return u.m=m,u.c=p,u.d=function(o,i,y){u.o(o,i)||Object.defineProperty(o,i,{enumerable:!0,get:y})},u.r=function(o){typeof Symbol<"u"&&Symbol.toStringTag&&Object.defineProperty(o,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(o,"__esModule",{value:!0})},u.t=function(o,i){if(1&i&&(o=u(o)),8&i||4&i&&typeof o=="object"&&o&&o.__esModule)return o;var y=Object.create(null);if(u.r(y),Object.defineProperty(y,"default",{enumerable:!0,value:o}),2&i&&typeof o!="string")for(var w in o)u.d(y,w,function(x){return o[x]}.bind(null,w));return y},u.n=function(o){var i=o&&o.__esModule?function(){return o.default}:function(){return o};return u.d(i,"a",i),i},u.o=function(o,i){return Object.prototype.hasOwnProperty.call(o,i)},u.p="",u(u.s=1)}([function(m,p,u){"use strict";(function(o){u.d(p,"a",function(){return k}),Array.isArray;const i=d=>{const A=Object.create(null);return g=>A[g]||(A[g]=d(g))},y=/-(\w)/g,w=(i(d=>d.replace(y,(A,g)=>g?g.toUpperCase():"")),/\B([A-Z])/g),x=(i(d=>d.replace(w,"-$1").toLowerCase()),i(d=>d.charAt(0).toUpperCase()+d.slice(1))),k=i(d=>d?"on"+x(d):"")}).call(this,u(2))},function(m,p,u){m.exports=u(3)},function(m,p){var u;u=function(){return this}();try{u=u||new Function("return this")()}catch{typeof window=="object"&&(u=window)}m.exports=u},function(m,p,u){"use strict";u.r(p),u.d(p,"default",function(){return Q});var o=u(0),i=/-(\w)/g,y=function(t){return t.replace(i,function(n,r){return r?r.toUpperCase():""})},w=/\B([A-Z])/g,x=function(t){return t.replace(w,"-$1").toLowerCase()};function k(t,n){if(t){var r=t.$options[n]||[];Array.isArray(r)||(r=[r]),r.forEach(function(c){c.call(t)})}}function d(t,n){return new CustomEvent(t,{bubbles:!1,cancelable:!1,detail:n.length===1?n[0]:n})}var A=function(t){return/function Boolean/.test(String(t))},g=function(t){return/function Number/.test(String(t))};function z(t,n){if(t.nodeType===3)return t.data.trim()?t.data:null;if(t.nodeType===1){var r={attrs:J(t),domProps:{innerHTML:t.innerHTML}};return r.attrs.slot&&(r.slot=r.attrs.slot,delete r.attrs.slot),n(t.tagName,r)}return null}function J(t){for(var n={},r=0,c=t.attributes.length;r<c;r++){var b=t.attributes[r];n[b.nodeName]=b.nodeValue}return n}function D(t){return(D=typeof Symbol=="function"&&typeof Symbol.iterator=="symbol"?function(n){return typeof n}:function(n){return n&&typeof Symbol=="function"&&n.constructor===Symbol&&n!==Symbol.prototype?"symbol":typeof n})(t)}function B(t,n){for(var r=0;r<n.length;r++){var c=n[r];c.enumerable=c.enumerable||!1,c.configurable=!0,"value"in c&&(c.writable=!0),Object.defineProperty(t,c.key,c)}}function K(t,n){return!n||D(n)!=="object"&&typeof n!="function"?M(t):n}function M(t){if(t===void 0)throw new ReferenceError("this hasn't been initialised - super() hasn't been called");return t}function H(t){var n=typeof Map=="function"?new Map:void 0;return(H=function(r){if(r===null||(c=r,Function.toString.call(c).indexOf("[native code]")===-1))return r;var c;if(typeof r!="function")throw new TypeError("Super expression must either be null or a function");if(n!==void 0){if(n.has(r))return n.get(r);n.set(r,b)}function b(){return I(r,arguments,N(this).constructor)}return b.prototype=Object.create(r.prototype,{constructor:{value:b,enumerable:!1,writable:!0,configurable:!0}}),T(b,r)})(t)}function I(t,n,r){return(I=V()?Reflect.construct:function(c,b,j){var O=[null];O.push.apply(O,b);var h=new(Function.bind.apply(c,O));return j&&T(h,j.prototype),h}).apply(null,arguments)}function V(){if(typeof Reflect>"u"||!Reflect.construct||Reflect.construct.sham)return!1;if(typeof Proxy=="function")return!0;try{return Date.prototype.toString.call(Reflect.construct(Date,[],function(){})),!0}catch{return!1}}function T(t,n){return(T=Object.setPrototypeOf||function(r,c){return r.__proto__=c,r})(t,n)}function N(t){return(N=Object.setPrototypeOf?Object.getPrototypeOf:function(n){return n.__proto__||Object.getPrototypeOf(n)})(t)}function Q(t,n,r,c){var b,j,O,h=t,R=!1,W=function(S){(function(e,a){if(typeof a!="function"&&a!==null)throw new TypeError("Super expression must either be null or a function");e.prototype=Object.create(a&&a.prototype,{constructor:{value:e,writable:!0,configurable:!0}}),a&&T(e,a)})(E,S);var L,C,P,F,Z,X=(L=E,C=V(),function(){var e,a=N(L);if(C){var f=N(this).constructor;e=Reflect.construct(a,arguments,f)}else e=a.apply(this,arguments);return K(this,e)});function E(){var e;(function(l,s){if(!(l instanceof s))throw new TypeError("Cannot call a class as a function")})(this,E),(e=X.call(this))._wrapper=void 0,e._component=void 0,e._props=void 0,e._slotChildren=void 0,e._mounted=!1;var a=e.createEventProxies(h.emits);e._props={},e._slotChildren=[];var f=M(e);return e._wrapper=n({render:function(){var l=Object.assign({},f._props,a);return delete l.dataVApp,r(h,l,function(){return f._slotChildren})},mounted:function(){f._mounted=!0},unmounted:function(){f._mounted=!1}}),new MutationObserver(function(l){for(var s=0;s<l.length;s++){var v=l[s];R&&v.type==="attributes"&&v.target===M(e)&&v.attributeName&&e.syncAttribute(v.attributeName)}}).observe(M(e),{childList:!0,subtree:!0,characterData:!0,attributes:!0}),e}return P=E,(F=[{key:"createEventProxies",value:function(e){var a=this,f={};return e&&e.forEach(function(l){var s=Object(o.a)(y(l));f[s]=function(){for(var v=arguments.length,U=new Array(v),_=0;_<v;_++)U[_]=arguments[_];a.dispatchEvent(d(l,U))}}),f}},{key:"syncAttribute",value:function(e){var a,f=y(e),l=void 0;this.hasOwnProperty(e)?l=this[e]:this.hasAttribute(e)&&(l=this.getAttribute(e)),this._props[f]=function(s,v){var U=arguments.length>2&&arguments[2]!==void 0?arguments[2]:{},_=U.type;if(A(_))return s==="true"||s==="false"?s==="true":s===""||s===v||s!=null;if(g(_)){var G=parseFloat(s);return isNaN(G)?s:G}return s}(l,e,O[f]),(a=this._component)===null||a===void 0||a.$forceUpdate()}},{key:"syncSlots",value:function(){var e;this._slotChildren=function(a,f){for(var l=[],s=0,v=a.length;s<v;s++)l.push(z(a[s],f));return l}(this.childNodes,r),(e=this._component)===null||e===void 0||e.$forceUpdate()}},{key:"syncInitialAttributes",value:function(){var e,a=this;this._props=(e={},j.forEach(function(f){e[f]=void 0}),e),b.forEach(function(f){a.syncAttribute(f)})}},{key:"connectedCallback",value:function(){this._component&&this._mounted?k(this._component,"mounted"):(R&&this.syncInitialAttributes(),this.syncSlots(),this._component=this._wrapper.mount(this)),c!=null&&c.connectedCallback&&c.connectedCallback.bind(this)()}},{key:"disconnectedCallback",value:function(){k(this._component,"unmounted")}}])&&B(P.prototype,F),Z&&B(P,Z),E}(H(HTMLElement));return function(){if(!R){var S=Array.isArray(h.props)?h.props:Object.keys(h.props||{});b=S.map(x),j=S.map(y);var L=Array.isArray(h.props)?{}:h.props||{};O=j.reduce(function(C,P,F){return C[P]=L[S[F]],C},{}),R=!0}}(),W}}]).default})})($,$.exports);const rt=tt($.exports);export{rt as w};
