gx.evt.autoSkip=!1;gx.define("promotion",!1,function(){var n,t;this.ServerClass="promotion";this.PackageName="GeneXus.Programs";this.ServerFullClass="promotion.aspx";this.setObjectType("trn");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7PromotionId=gx.fn.getIntegerValue("vPROMOTIONID",".");this.A40000PromotionPhoto_GXI=gx.fn.getControlValue("PROMOTIONPHOTO_GXI");this.AV11Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Promotionid=function(){return this.validCliEvt("Valid_Promotionid",0,function(){try{var n=gx.util.balloon.getNew("PROMOTIONID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Datestart=function(){return this.validCliEvt("Valid_Datestart",0,function(){try{var n=gx.util.balloon.getNew("DATESTART");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A31DateStart)==0||new gx.date.gxdate(this.A31DateStart).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Date Start fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Datefinish=function(){return this.validCliEvt("Valid_Datefinish",0,function(){try{var n=gx.util.balloon.getNew("DATEFINISH");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.A32DateFinish)==0||new gx.date.gxdate(this.A32DateFinish).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Date Finish fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}if(new gx.date.gxdate(this.A31DateStart).compare(this.A32DateFinish)>0)try{n.setError("A data de início não pode ser posterior à data de término");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Productid=function(){var t=gx.fn.currentGridRowImpl(63),n;return gx.fn.currentGridRowImpl(63)===0?!0:(n=gx.util.balloon.getNew("PRODUCTID",gx.fn.currentGridRowImpl(63)),gx.fn.gridDuplicateKey(64))?(n.setError(gx.text.format(gx.getMessage("GXM_1004"),"Product","","","","","","","","")),this.AnyError=gx.num.trunc(1,0),n.show()):this.validSrvEvt("Valid_Productid",63).then(function(n){try{this.sMode8=this.Gx_mode;this.Gx_mode=gx.fn.getGridRowMode(8,63);this.standaloneModal088();this.standaloneNotModal088()}finally{this.Gx_mode=this.sMode8}return n}.closure(this))};this.standaloneModal088=function(){try{gx.text.compare(this.Gx_mode,"INS")!=0?gx.fn.setCtrlProperty("PRODUCTID","Enabled",0):gx.fn.setCtrlProperty("PRODUCTID","Enabled",1)}catch(n){}};this.standaloneNotModal088=function(){};this.e12082_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13087_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14087_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,64,65,66,67,68,69,70,71,72,73,74,75,76];this.GXLastCtrlId=76;this.Gridpromotion_productContainer=new gx.grid.grid(this,8,"Product",63,"Gridpromotion_product","Gridpromotion_product","Gridpromotion_productContainer",this.CmpContext,this.IsMasterPage,"promotion",[12],!1,1,!1,!0,5,!1,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Gridpromotion_productContainer;t.addSingleLineEdit(12,64,"PRODUCTID","Product Id","","ProductId","int",0,"px",4,4,"right",null,[],12,"ProductId",!0,0,!1,!1,"Attribute",1,"");t.addBitmap("prompt_12","PROMPT_12",76,0,"",0,"",null,"","","gx-prompt Image","");t.addSingleLineEdit(13,65,"PRODUCTNAME","Nome do Produto","","ProductName","char",0,"px",20,20,"left",null,[],13,"ProductName",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(27,66,"PRODUCTPRICE","Preço","","ProductPrice","decimal",0,"px",11,11,"right",null,[],27,"ProductPrice",!0,2,!1,!1,"Attribute",1,"");this.Gridpromotion_productContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15087_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16087_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17087_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18087_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19087_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Promotionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Gridpromotion_productContainer],fld:"PROMOTIONID",gxz:"Z15PromotionId",gxold:"O15PromotionId",gxvar:"A15PromotionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15PromotionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15PromotionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PROMOTIONID",gx.O.A15PromotionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A15PromotionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PROMOTIONID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROMOTIONDESCRIPTION",gxz:"Z29PromotionDescription",gxold:"O29PromotionDescription",gxvar:"A29PromotionDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A29PromotionDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z29PromotionDescription=n)},v2c:function(){gx.fn.setControlValue("PROMOTIONDESCRIPTION",gx.O.A29PromotionDescription,0)},c2v:function(){this.val()!==undefined&&(gx.O.A29PromotionDescription=this.val())},val:function(){return gx.fn.getControlValue("PROMOTIONDESCRIPTION")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROMOTIONPHOTO",gxz:"Z30PromotionPhoto",gxold:"O30PromotionPhoto",gxvar:"A30PromotionPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30PromotionPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z30PromotionPhoto=n)},v2c:function(){gx.fn.setMultimediaValue("PROMOTIONPHOTO",gx.O.A30PromotionPhoto,gx.O.A40000PromotionPhoto_GXI)},c2v:function(){gx.O.A40000PromotionPhoto_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A30PromotionPhoto=this.val())},val:function(){return gx.fn.getBlobValue("PROMOTIONPHOTO")},val_GXI:function(){return gx.fn.getControlValue("PROMOTIONPHOTO_GXI")},gxvar_GXI:"A40000PromotionPhoto_GXI",nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Datestart,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DATESTART",gxz:"Z31DateStart",gxold:"O31DateStart",gxvar:"A31DateStart",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[49],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A31DateStart=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z31DateStart=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("DATESTART",gx.O.A31DateStart,0)},c2v:function(){this.val()!==undefined&&(gx.O.A31DateStart=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("DATESTART")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Datefinish,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DATEFINISH",gxz:"Z32DateFinish",gxold:"O32DateFinish",gxvar:"A32DateFinish",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[49,54],ip:[49,54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A32DateFinish=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z32DateFinish=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("DATEFINISH",gx.O.A32DateFinish,0)},c2v:function(){this.val()!==undefined&&(gx.O.A32DateFinish=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("DATEFINISH")},nac:gx.falseFn};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"PRODUCTTABLE",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"TITLEPRODUCT",format:0,grid:0,ctrltype:"textblock"};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[64]={id:64,lvl:8,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:1,grid:63,gxgrid:this.Gridpromotion_productContainer,fnc:this.Valid_Productid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",gxz:"Z12ProductId",gxold:"O12ProductId",gxvar:"A12ProductId",ucs:[],op:[66,65],ip:[66,65,64],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A12ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(63),gx.O.A12ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(63),".")},nac:gx.falseFn};n[65]={id:65,lvl:8,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:1,grid:63,gxgrid:this.Gridpromotion_productContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",gxz:"Z13ProductName",gxold:"O13ProductName",gxvar:"A13ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A13ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z13ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(63),gx.O.A13ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A13ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(63))},nac:gx.falseFn};n[66]={id:66,lvl:8,type:"decimal",len:8,dec:2,sign:!1,pic:"R$ ZZZZ9.99",ro:1,isacc:1,grid:63,gxgrid:this.Gridpromotion_productContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPRICE",gxz:"Z27ProductPrice",gxold:"O27ProductPrice",gxvar:"A27ProductPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27ProductPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z27ProductPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(63),gx.O.A27ProductPrice,2,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27ProductPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(63),".",",")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTN_ENTER",grid:0,evt:"e13087_client",std:"ENTER"};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"BTN_CANCEL",grid:0,evt:"e14087_client"};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"BTN_DELETE",grid:0,evt:"e20087_client",std:"DELETE"};n[76]={id:76,fld:"PROMPT_12",grid:8};this.A15PromotionId=0;this.Z15PromotionId=0;this.O15PromotionId=0;this.A29PromotionDescription="";this.Z29PromotionDescription="";this.O29PromotionDescription="";this.A40000PromotionPhoto_GXI="";this.A30PromotionPhoto="";this.Z30PromotionPhoto="";this.O30PromotionPhoto="";this.A31DateStart=gx.date.nullDate();this.Z31DateStart=gx.date.nullDate();this.O31DateStart=gx.date.nullDate();this.A32DateFinish=gx.date.nullDate();this.Z32DateFinish=gx.date.nullDate();this.O32DateFinish=gx.date.nullDate();this.Z12ProductId=0;this.O12ProductId=0;this.Z13ProductName="";this.O13ProductName="";this.Z27ProductPrice=0;this.O27ProductPrice=0;this.A12ProductId=0;this.A13ProductName="";this.A27ProductPrice=0;this.A40000PromotionPhoto_GXI="";this.AV11Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7PromotionId=0;this.AV10WebSession={};this.A15PromotionId=0;this.A29PromotionDescription="";this.A30PromotionPhoto="";this.A31DateStart=gx.date.nullDate();this.A32DateFinish=gx.date.nullDate();this.Gx_mode="";this.Events={e12082_client:["AFTER TRN",!0],e13087_client:["ENTER",!0],e14087_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7PromotionId",fld:"vPROMOTIONID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7PromotionId",fld:"vPROMOTIONID",pic:"ZZZ9",hsh:!0},{av:"A15PromotionId",fld:"PROMOTIONID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_PROMOTIONID=[[],[]];this.EvtParms.VALID_DATESTART=[[{av:"A31DateStart",fld:"DATESTART",pic:""}],[{av:"A31DateStart",fld:"DATESTART",pic:""}]];this.EvtParms.VALID_DATEFINISH=[[{av:"A31DateStart",fld:"DATESTART",pic:""},{av:"A32DateFinish",fld:"DATEFINISH",pic:""}],[{av:"A31DateStart",fld:"DATESTART",pic:""},{av:"A32DateFinish",fld:"DATEFINISH",pic:""}]];this.EvtParms.VALID_PRODUCTID=[[{av:"A12ProductId",fld:"PRODUCTID",pic:"ZZZ9"},{av:"A13ProductName",fld:"PRODUCTNAME",pic:""},{av:"A27ProductPrice",fld:"PRODUCTPRICE",pic:"R$ ZZZZ9.99"}],[{av:"A13ProductName",fld:"PRODUCTNAME",pic:""},{av:"A27ProductPrice",fld:"PRODUCTPRICE",pic:"R$ ZZZZ9.99"}]];this.setPrompt("PROMPT_12",[64]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7PromotionId","vPROMOTIONID",0,"int",4,0);this.setVCMap("A40000PromotionPhoto_GXI","PROMOTIONPHOTO_GXI",0,"svchar",2048,0);this.setVCMap("AV11Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);t.addPostingVar({rfrVar:"Gx_mode"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.promotion)})