gx.evt.autoSkip=!1;gx.define("shoppingcart",!1,function(){var n,t;this.ServerClass="shoppingcart";this.PackageName="GeneXus.Programs";this.ServerFullClass="shoppingcart.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9ShoppingCartId=gx.fn.getIntegerValue("vSHOPPINGCARTID",".");this.AV7Insert_CustomerId=gx.fn.getIntegerValue("vINSERT_CUSTOMERID",".");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",".");this.AV14Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV10TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Shoppingcartid=function(){return this.validSrvEvt("Valid_Shoppingcartid",0).then(function(n){return n}.closure(this))};this.Valid_Shoppingcartdate=function(){return this.validCliEvt("Valid_Shoppingcartdate",0,function(){try{var n=gx.util.balloon.getNew("SHOPPINGCARTDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A33ShoppingCartDate)==0||new gx.date.gxdate(this.A33ShoppingCartDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Shopping Cart Date fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}try{this.A38ShoppingCartDateDelivery=gx.date.addDays(this.A33ShoppingCartDate,5)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Customerid=function(){return this.validSrvEvt("Valid_Customerid",0).then(function(n){return n}.closure(this))};this.Valid_Countryid=function(){return this.validCliEvt("Valid_Countryid",0,function(){try{var n=gx.util.balloon.getNew("COUNTRYID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Productid=function(){var t=gx.fn.currentGridRowImpl(88),n;return gx.fn.currentGridRowImpl(88)===0?!0:(n=gx.util.balloon.getNew("PRODUCTID",gx.fn.currentGridRowImpl(88)),gx.fn.gridDuplicateKey(89))?(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Product","","","","","","","","")),this.AnyError=gx.num.trunc(1,0),n.show()):this.validSrvEvt("Valid_Productid",88).then(function(n){try{this.sMode10=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(10,88);this.standaloneModal0610();this.standaloneNotModal0610()}finally{this.Gx_mode=this.sMode10}return n}.closure(this))};this.Valid_Productprice=function(){var n=gx.fn.currentGridRowImpl(88);return this.validCliEvt("Valid_Productprice",88,function(){try{if(gx.fn.currentGridRowImpl(88)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTPRICE",gx.fn.currentGridRowImpl(88));this.AnyError=0;this.sMode10=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(10,88)}catch(t){}try{return(this.Gx_mode=this.sMode10,n==null)?!0:n.show()}catch(t){}return!0})};this.Valid_Qtyproduct=function(){var n=gx.fn.currentGridRowImpl(88);return this.validCliEvt("Valid_Qtyproduct",88,function(){try{if(gx.fn.currentGridRowImpl(88)===0)return!0;var t=gx.util.balloon.getNew("QTYPRODUCT",gx.fn.currentGridRowImpl(88));this.AnyError=0;this.sMode10=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(10,88);try{this.A35TotalProduct=gx.text.compare(this.A7CategoryName,"Entretenimiento")==0?this.A27ProductPrice*.9*this.A36QtyProduct:gx.text.compare(this.A7CategoryName,"Joyería")==0?this.A27ProductPrice*1.05*this.A36QtyProduct:this.A27ProductPrice*this.A36QtyProduct}catch(i){}try{this.A34ShoppingCartFinalPrice=gx.fn.sumFrm("A35TotalProduct",0,".",",",88,n,gx.trueFn,[])}catch(i){}}catch(i){}try{return(this.Gx_mode=this.sMode10,t==null)?!0:t.show()}catch(i){}return!0})};this.Valid_Totalproduct=function(){var n=gx.fn.currentGridRowImpl(88);return this.validCliEvt("Valid_Totalproduct",88,function(){try{if(gx.fn.currentGridRowImpl(88)===0)return!0;var n=gx.util.balloon.getNew("TOTALPRODUCT",gx.fn.currentGridRowImpl(88));this.AnyError=0;this.sMode10=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(10,88)}catch(t){}try{return(this.Gx_mode=this.sMode10,n==null)?!0:n.show()}catch(t){}return!0})};this.Valid_Categoryid=function(){var n=gx.fn.currentGridRowImpl(88);return this.validCliEvt("Valid_Categoryid",88,function(){try{if(gx.fn.currentGridRowImpl(88)===0)return!0;var n=gx.util.balloon.getNew("CATEGORYID",gx.fn.currentGridRowImpl(88));this.AnyError=0;this.sMode10=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(10,88)}catch(t){}try{return(this.Gx_mode=this.sMode10,n==null)?!0:n.show()}catch(t){}return!0})};this.Valid_Categoryname=function(){var n=gx.fn.currentGridRowImpl(88);return this.validCliEvt("Valid_Categoryname",88,function(){try{if(gx.fn.currentGridRowImpl(88)===0)return!0;var n=gx.util.balloon.getNew("CATEGORYNAME",gx.fn.currentGridRowImpl(88));this.AnyError=0;this.sMode10=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(10,88);gx.text.compare(this.Gx_mode,"UPD")==0}catch(t){}try{return(this.Gx_mode=this.sMode10,n==null)?!0:n.show()}catch(t){}return!0})};this.standaloneModal0610=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("PRODUCTID","Enabled",0):gx.fn.setCtrlProperty("PRODUCTID","Enabled",1)}catch(n){}};this.standaloneNotModal0610=function(){};this.e12062_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13069_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14069_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106];this.GXLastCtrlId=106;this.Gridshoppingcart_productContainer=new gx.grid.grid(this,10,"Product",88,"Gridshoppingcart_product","Gridshoppingcart_product","Gridshoppingcart_productContainer",this.CmpContext,this.IsMasterPage,"shoppingcart",[12],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridshoppingcart_productContainer;t.addSingleLineEdit(12,89,"PRODUCTID","Product Id","","ProductId","int",0,"px",4,4,"right",null,[],12,"ProductId",!0,0,!1,!1,"Attribute",1,"");t.addBitmap("prompt_12","PROMPT_12",106,0,"",0,"",null,"","","gx-prompt Image","");t.addSingleLineEdit(13,90,"PRODUCTNAME","Nome do Produto","","ProductName","char",0,"px",20,20,"left",null,[],13,"ProductName",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(27,91,"PRODUCTPRICE","Preço","","ProductPrice","decimal",0,"px",11,11,"right",null,[],27,"ProductPrice",!0,2,!1,!1,"Attribute",1,"");t.addSingleLineEdit(36,92,"QTYPRODUCT","Product","","QtyProduct","int",0,"px",4,4,"right",null,[],36,"QtyProduct",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(35,93,"TOTALPRODUCT","Product","","TotalProduct","decimal",0,"px",11,11,"right",null,[],35,"TotalProduct",!0,2,!1,!1,"Attribute",1,"");t.addSingleLineEdit(6,94,"CATEGORYID","Categoria Id","","CategoryId","int",0,"px",4,4,"right",null,[],6,"CategoryId",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(7,95,"CATEGORYNAME","Noma da Categoria","","CategoryName","char",0,"px",20,20,"left",null,[],7,"CategoryName",!0,0,!1,!1,"Attribute",1,"");this.Gridshoppingcart_productContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15069_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16069_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17069_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18069_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19069_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Shoppingcartid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridshoppingcart_productContainer],fld:"SHOPPINGCARTID",gxz:"Z16ShoppingCartId",gxold:"O16ShoppingCartId",gxvar:"A16ShoppingCartId",ucs:[],op:[79],ip:[79,34],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A16ShoppingCartId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z16ShoppingCartId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SHOPPINGCARTID",gx.O.A16ShoppingCartId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A16ShoppingCartId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SHOPPINGCARTID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Shoppingcartdate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTDATE",gxz:"Z33ShoppingCartDate",gxold:"O33ShoppingCartDate",gxvar:"A33ShoppingCartDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[39,44],ip:[44,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A33ShoppingCartDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z33ShoppingCartDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("SHOPPINGCARTDATE",gx.O.A33ShoppingCartDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.A33ShoppingCartDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("SHOPPINGCARTDATE")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTDATEDELIVERY",gxz:"Z38ShoppingCartDateDelivery",gxold:"O38ShoppingCartDateDelivery",gxvar:"A38ShoppingCartDateDelivery",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A38ShoppingCartDateDelivery=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z38ShoppingCartDateDelivery=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("SHOPPINGCARTDATEDELIVERY",gx.O.A38ShoppingCartDateDelivery,0)},c2v:function(){this.val()!==undefined&&(gx.O.A38ShoppingCartDateDelivery=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("SHOPPINGCARTDATEDELIVERY")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Customerid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERID",gxz:"Z11CustomerId",gxold:"O11CustomerId",gxvar:"A11CustomerId",ucs:[],op:[64,59,74,69,54],ip:[64,74,69,54,59,49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A11CustomerId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z11CustomerId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUSTOMERID",gx.O.A11CustomerId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A11CustomerId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUSTOMERID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV7Insert_CustomerId)}};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERNAME",gxz:"Z20CustomerName",gxold:"O20CustomerName",gxvar:"A20CustomerName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A20CustomerName=n)},v2z:function(n){n!==undefined&&(gx.O.Z20CustomerName=n)},v2c:function(){gx.fn.setControlValue("CUSTOMERNAME",gx.O.A20CustomerName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A20CustomerName=this.val())},val:function(){return gx.fn.getControlValue("CUSTOMERNAME")},nac:gx.falseFn};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Countryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYID",gxz:"Z8CountryId",gxold:"O8CountryId",gxvar:"A8CountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z8CountryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COUNTRYID",gx.O.A8CountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8CountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COUNTRYID",".")},nac:gx.falseFn};this.declareDomainHdlr(59,function(){});n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",gxz:"Z9CountryName",gxold:"O9CountryName",gxvar:"A9CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z9CountryName=n)},v2c:function(){gx.fn.setControlValue("COUNTRYNAME",gx.O.A9CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9CountryName=this.val())},val:function(){return gx.fn.getControlValue("COUNTRYNAME")},nac:gx.falseFn};this.declareDomainHdlr(64,function(){});n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"",grid:0};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,lvl:0,type:"svchar",len:1024,dec:0,sign:!1,ro:1,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERADDRESS",gxz:"Z21CustomerAddress",gxold:"O21CustomerAddress",gxvar:"A21CustomerAddress",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A21CustomerAddress=n)},v2z:function(n){n!==undefined&&(gx.O.Z21CustomerAddress=n)},v2c:function(){gx.fn.setControlValue("CUSTOMERADDRESS",gx.O.A21CustomerAddress,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A21CustomerAddress=this.val())},val:function(){return gx.fn.getControlValue("CUSTOMERADDRESS")},nac:gx.falseFn};this.declareDomainHdlr(69,function(){gx.fn.setCtrlProperty("CUSTOMERADDRESS","Link",gx.fn.getCtrlProperty("CUSTOMERADDRESS","Enabled")?"":"http://maps.google.com/maps?q="+encodeURIComponent(this.A21CustomerAddress))});n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,lvl:0,type:"char",len:20,dec:0,sign:!1,pic:"(99) 9999-9999",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERPHONE",gxz:"Z23CustomerPhone",gxold:"O23CustomerPhone",gxvar:"A23CustomerPhone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A23CustomerPhone=n)},v2z:function(n){n!==undefined&&(gx.O.Z23CustomerPhone=n)},v2c:function(){gx.fn.setControlValue("CUSTOMERPHONE",gx.O.A23CustomerPhone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A23CustomerPhone=this.val())},val:function(){return gx.fn.getControlValue("CUSTOMERPHONE")},nac:gx.falseFn};this.declareDomainHdlr(74,function(){});n[75]={id:75,fld:"",grid:0};n[76]={id:76,fld:"",grid:0};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[79]={id:79,lvl:0,type:"decimal",len:10,dec:2,sign:!1,pic:"$ ZZZZZZ9.99",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTFINALPRICE",gxz:"Z34ShoppingCartFinalPrice",gxold:"O34ShoppingCartFinalPrice",gxvar:"A34ShoppingCartFinalPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A34ShoppingCartFinalPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z34ShoppingCartFinalPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(){gx.fn.setDecimalValue("SHOPPINGCARTFINALPRICE",gx.O.A34ShoppingCartFinalPrice,2,",")},c2v:function(){this.val()!==undefined&&(gx.O.A34ShoppingCartFinalPrice=this.val())},val:function(){return gx.fn.getDecimalValue("SHOPPINGCARTFINALPRICE",".",",")},nac:gx.falseFn};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"PRODUCTTABLE",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"",grid:0};n[85]={id:85,fld:"TITLEPRODUCT",format:0,grid:0,ctrltype:"textblock"};n[86]={id:86,fld:"",grid:0};n[87]={id:87,fld:"",grid:0};n[89]={id:89,lvl:10,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:1,grid:88,gxgrid:this.Gridshoppingcart_productContainer,fnc:this.Valid_Productid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",gxz:"Z12ProductId",gxold:"O12ProductId",gxvar:"A12ProductId",ucs:[],op:[95,94,91,90],ip:[95,91,90,94,89],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A12ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(88),gx.O.A12ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(88),".")},nac:gx.falseFn};n[90]={id:90,lvl:10,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:1,grid:88,gxgrid:this.Gridshoppingcart_productContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",gxz:"Z13ProductName",gxold:"O13ProductName",gxvar:"A13ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A13ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z13ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(88),gx.O.A13ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A13ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(88))},nac:gx.falseFn};n[91]={id:91,lvl:10,type:"decimal",len:8,dec:2,sign:!1,pic:"R$ ZZZZ9.99",ro:1,isacc:1,grid:88,gxgrid:this.Gridshoppingcart_productContainer,fnc:this.Valid_Productprice,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPRICE",gxz:"Z27ProductPrice",gxold:"O27ProductPrice",gxvar:"A27ProductPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27ProductPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z27ProductPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(88),gx.O.A27ProductPrice,2,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27ProductPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(88),".",",")},nac:gx.falseFn};n[92]={id:92,lvl:10,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:1,grid:88,gxgrid:this.Gridshoppingcart_productContainer,fnc:this.Valid_Qtyproduct,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"QTYPRODUCT",gxz:"Z36QtyProduct",gxold:"O36QtyProduct",gxvar:"A36QtyProduct",ucs:[],op:[79,93],ip:[79,93,95,92,91],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A36QtyProduct=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z36QtyProduct=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("QTYPRODUCT",n||gx.fn.currentGridRowImpl(88),gx.O.A36QtyProduct,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A36QtyProduct=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("QTYPRODUCT",n||gx.fn.currentGridRowImpl(88),".")},nac:gx.falseFn};n[93]={id:93,lvl:10,type:"decimal",len:8,dec:2,sign:!1,pic:"R$ ZZZZ9.99",ro:1,isacc:1,grid:88,gxgrid:this.Gridshoppingcart_productContainer,fnc:this.Valid_Totalproduct,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TOTALPRODUCT",gxz:"Z35TotalProduct",gxold:"O35TotalProduct",gxvar:"A35TotalProduct",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A35TotalProduct=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z35TotalProduct=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("TOTALPRODUCT",n||gx.fn.currentGridRowImpl(88),gx.O.A35TotalProduct,2,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A35TotalProduct=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("TOTALPRODUCT",n||gx.fn.currentGridRowImpl(88),".",",")},nac:gx.falseFn};n[94]={id:94,lvl:10,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:1,grid:88,gxgrid:this.Gridshoppingcart_productContainer,fnc:this.Valid_Categoryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORYID",gxz:"Z6CategoryId",gxold:"O6CategoryId",gxvar:"A6CategoryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A6CategoryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z6CategoryId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CATEGORYID",n||gx.fn.currentGridRowImpl(88),gx.O.A6CategoryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6CategoryId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CATEGORYID",n||gx.fn.currentGridRowImpl(88),".")},nac:gx.falseFn};n[95]={id:95,lvl:10,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:1,grid:88,gxgrid:this.Gridshoppingcart_productContainer,fnc:this.Valid_Categoryname,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORYNAME",gxz:"Z7CategoryName",gxold:"O7CategoryName",gxvar:"A7CategoryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A7CategoryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z7CategoryName=n)},v2c:function(n){gx.fn.setGridControlValue("CATEGORYNAME",n||gx.fn.currentGridRowImpl(88),gx.O.A7CategoryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7CategoryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CATEGORYNAME",n||gx.fn.currentGridRowImpl(88))},nac:gx.falseFn};n[96]={id:96,fld:"",grid:0};n[97]={id:97,fld:"",grid:0};n[98]={id:98,fld:"",grid:0};n[99]={id:99,fld:"",grid:0};n[100]={id:100,fld:"BTN_ENTER",grid:0,evt:"e13069_client",std:"ENTER"};n[101]={id:101,fld:"",grid:0};n[102]={id:102,fld:"BTN_CANCEL",grid:0,evt:"e14069_client"};n[103]={id:103,fld:"",grid:0};n[104]={id:104,fld:"BTN_DELETE",grid:0,evt:"e20069_client",std:"DELETE"};n[105]={id:105,fld:"PROMPT_11",grid:9};n[106]={id:106,fld:"PROMPT_12",grid:10};this.A16ShoppingCartId=0;this.Z16ShoppingCartId=0;this.O16ShoppingCartId=0;this.A33ShoppingCartDate=gx.date.nullDate();this.Z33ShoppingCartDate=gx.date.nullDate();this.O33ShoppingCartDate=gx.date.nullDate();this.A38ShoppingCartDateDelivery=gx.date.nullDate();this.Z38ShoppingCartDateDelivery=gx.date.nullDate();this.O38ShoppingCartDateDelivery=gx.date.nullDate();this.A11CustomerId=0;this.Z11CustomerId=0;this.O11CustomerId=0;this.A20CustomerName="";this.Z20CustomerName="";this.O20CustomerName="";this.A8CountryId=0;this.Z8CountryId=0;this.O8CountryId=0;this.A9CountryName="";this.Z9CountryName="";this.O9CountryName="";this.A21CustomerAddress="";this.Z21CustomerAddress="";this.O21CustomerAddress="";this.A23CustomerPhone="";this.Z23CustomerPhone="";this.O23CustomerPhone="";this.A34ShoppingCartFinalPrice=0;this.Z34ShoppingCartFinalPrice=0;this.O34ShoppingCartFinalPrice=0;this.Z12ProductId=0;this.O12ProductId=0;this.Z13ProductName="";this.O13ProductName="";this.Z27ProductPrice=0;this.O27ProductPrice=0;this.Z36QtyProduct=0;this.O36QtyProduct=0;this.Z35TotalProduct=0;this.O35TotalProduct=0;this.Z6CategoryId=0;this.O6CategoryId=0;this.Z7CategoryName="";this.O7CategoryName="";this.A12ProductId=0;this.A35TotalProduct=0;this.A13ProductName="";this.A27ProductPrice=0;this.A36QtyProduct=0;this.A6CategoryId=0;this.A7CategoryName="";this.AV14Pgmname="";this.AV10TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7Insert_CustomerId=0;this.AV15GXV1=0;this.AV11TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV9ShoppingCartId=0;this.AV12WebSession={};this.A16ShoppingCartId=0;this.A11CustomerId=0;this.Gx_BScreen=0;this.A38ShoppingCartDateDelivery=gx.date.nullDate();this.A33ShoppingCartDate=gx.date.nullDate();this.A20CustomerName="";this.A8CountryId=0;this.A9CountryName="";this.A21CustomerAddress="";this.A23CustomerPhone="";this.A34ShoppingCartFinalPrice=0;this.Gx_mode="";this.Events={e12062_client:["AFTER TRN",!0],e13069_client:["ENTER",!0],e14069_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9ShoppingCartId",fld:"vSHOPPINGCARTID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV10TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV9ShoppingCartId",fld:"vSHOPPINGCARTID",pic:"ZZZ9",hsh:!0},{av:"A16ShoppingCartId",fld:"SHOPPINGCARTID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"A16ShoppingCartId",fld:"SHOPPINGCARTID",pic:"ZZZ9"},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV10TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[{av:"A16ShoppingCartId",fld:"SHOPPINGCARTID",pic:"ZZZ9"}]];this.EvtParms.VALID_SHOPPINGCARTID=[[{av:"A16ShoppingCartId",fld:"SHOPPINGCARTID",pic:"ZZZ9"},{av:"A34ShoppingCartFinalPrice",fld:"SHOPPINGCARTFINALPRICE",pic:"$ ZZZZZZ9.99"}],[{av:"A34ShoppingCartFinalPrice",fld:"SHOPPINGCARTFINALPRICE",pic:"$ ZZZZZZ9.99"}]];this.EvtParms.VALID_SHOPPINGCARTDATE=[[{av:"A38ShoppingCartDateDelivery",fld:"SHOPPINGCARTDATEDELIVERY",pic:""},{av:"A33ShoppingCartDate",fld:"SHOPPINGCARTDATE",pic:""}],[{av:"A33ShoppingCartDate",fld:"SHOPPINGCARTDATE",pic:""},{av:"A38ShoppingCartDateDelivery",fld:"SHOPPINGCARTDATEDELIVERY",pic:""}]];this.EvtParms.VALID_CUSTOMERID=[[{av:"A11CustomerId",fld:"CUSTOMERID",pic:"ZZZ9"},{av:"A8CountryId",fld:"COUNTRYID",pic:"ZZZ9"},{av:"A20CustomerName",fld:"CUSTOMERNAME",pic:""},{av:"A21CustomerAddress",fld:"CUSTOMERADDRESS",pic:""},{av:"A23CustomerPhone",fld:"CUSTOMERPHONE",pic:"(99) 9999-9999"},{av:"A9CountryName",fld:"COUNTRYNAME",pic:""}],[{av:"A20CustomerName",fld:"CUSTOMERNAME",pic:""},{av:"A21CustomerAddress",fld:"CUSTOMERADDRESS",pic:""},{av:"A23CustomerPhone",fld:"CUSTOMERPHONE",pic:"(99) 9999-9999"},{av:"A8CountryId",fld:"COUNTRYID",pic:"ZZZ9"},{av:"A9CountryName",fld:"COUNTRYNAME",pic:""}]];this.EvtParms.VALID_COUNTRYID=[[],[]];this.EvtParms.VALID_PRODUCTID=[[{av:"A12ProductId",fld:"PRODUCTID",pic:"ZZZ9"},{av:"A6CategoryId",fld:"CATEGORYID",pic:"ZZZ9"},{av:"A13ProductName",fld:"PRODUCTNAME",pic:""},{av:"A27ProductPrice",fld:"PRODUCTPRICE",pic:"R$ ZZZZ9.99"},{av:"A7CategoryName",fld:"CATEGORYNAME",pic:""}],[{av:"A13ProductName",fld:"PRODUCTNAME",pic:""},{av:"A27ProductPrice",fld:"PRODUCTPRICE",pic:"R$ ZZZZ9.99"},{av:"A6CategoryId",fld:"CATEGORYID",pic:"ZZZ9"},{av:"A7CategoryName",fld:"CATEGORYNAME",pic:""}]];this.EvtParms.VALID_PRODUCTPRICE=[[],[]];this.EvtParms.VALID_QTYPRODUCT=[[{av:"A34ShoppingCartFinalPrice",fld:"SHOPPINGCARTFINALPRICE",pic:"$ ZZZZZZ9.99"},{av:"A35TotalProduct",fld:"TOTALPRODUCT",pic:"R$ ZZZZ9.99"},{av:"A7CategoryName",fld:"CATEGORYNAME",pic:""},{av:"A36QtyProduct",fld:"QTYPRODUCT",pic:"ZZZ9"},{av:"A27ProductPrice",fld:"PRODUCTPRICE",pic:"R$ ZZZZ9.99"}],[{av:"A34ShoppingCartFinalPrice",fld:"SHOPPINGCARTFINALPRICE",pic:"$ ZZZZZZ9.99"},{av:"A35TotalProduct",fld:"TOTALPRODUCT",pic:"R$ ZZZZ9.99"}]];this.EvtParms.VALID_TOTALPRODUCT=[[],[]];this.EvtParms.VALID_CATEGORYID=[[],[]];this.EvtParms.VALID_CATEGORYNAME=[[],[]];this.setPrompt("PROMPT_11",[49]);this.setPrompt("PROMPT_12",[89]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV9ShoppingCartId","vSHOPPINGCARTID",0,"int",4,0);this.setVCMap("AV7Insert_CustomerId","vINSERT_CUSTOMERID",0,"int",4,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV14Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV10TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize();this.LvlOlds[9]=["O34ShoppingCartFinalPrice"];this.LvlOlds[10]=["O35TotalProduct"]});gx.wi(function(){gx.createParentObj(this.shoppingcart)})