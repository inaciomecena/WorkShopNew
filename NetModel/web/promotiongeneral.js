gx.evt.autoSkip=!1;gx.define("promotiongeneral",!0,function(n){this.ServerClass="promotiongeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="promotiongeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Promotionid=function(){return this.validCliEvt("Valid_Promotionid",0,function(){try{var n=gx.util.balloon.getNew("PROMOTIONID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e111n1_client=function(){return this.clearMessages(),this.call("promotion.aspx",["UPD",this.A15PromotionId],null,["Mode","PromotionId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121n1_client=function(){return this.clearMessages(),this.call("promotion.aspx",["DLT",this.A15PromotionId],null,["Mode","PromotionId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e151n2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e161n2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39];this.GXLastCtrlId=39;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e111n1_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e121n1_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Promotionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROMOTIONID",gxz:"Z15PromotionId",gxold:"O15PromotionId",gxvar:"A15PromotionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15PromotionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15PromotionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PROMOTIONID",gx.O.A15PromotionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A15PromotionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PROMOTIONID",".")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROMOTIONDESCRIPTION",gxz:"Z29PromotionDescription",gxold:"O29PromotionDescription",gxvar:"A29PromotionDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A29PromotionDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z29PromotionDescription=n)},v2c:function(){gx.fn.setControlValue("PROMOTIONDESCRIPTION",gx.O.A29PromotionDescription,0)},c2v:function(){this.val()!==undefined&&(gx.O.A29PromotionDescription=this.val())},val:function(){return gx.fn.getControlValue("PROMOTIONDESCRIPTION")},nac:gx.falseFn};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DATESTART",gxz:"Z31DateStart",gxold:"O31DateStart",gxvar:"A31DateStart",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A31DateStart=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z31DateStart=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("DATESTART",gx.O.A31DateStart,0)},c2v:function(){this.val()!==undefined&&(gx.O.A31DateStart=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("DATESTART")},nac:gx.falseFn};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DATEFINISH",gxz:"Z32DateFinish",gxold:"O32DateFinish",gxvar:"A32DateFinish",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A32DateFinish=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z32DateFinish=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("DATEFINISH",gx.O.A32DateFinish,0)},c2v:function(){this.val()!==undefined&&(gx.O.A32DateFinish=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("DATEFINISH")},nac:gx.falseFn};t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"IMAGESTABLE",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,fld:"",grid:0};t[39]={id:39,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROMOTIONPHOTO",gxz:"Z30PromotionPhoto",gxold:"O30PromotionPhoto",gxvar:"A30PromotionPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30PromotionPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z30PromotionPhoto=n)},v2c:function(){gx.fn.setMultimediaValue("PROMOTIONPHOTO",gx.O.A30PromotionPhoto,gx.O.A40000PromotionPhoto_GXI)},c2v:function(){gx.O.A40000PromotionPhoto_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A30PromotionPhoto=this.val())},val:function(){return gx.fn.getBlobValue("PROMOTIONPHOTO")},val_GXI:function(){return gx.fn.getControlValue("PROMOTIONPHOTO_GXI")},gxvar_GXI:"A40000PromotionPhoto_GXI",nac:gx.falseFn};this.A15PromotionId=0;this.Z15PromotionId=0;this.O15PromotionId=0;this.A29PromotionDescription="";this.Z29PromotionDescription="";this.O29PromotionDescription="";this.A31DateStart=gx.date.nullDate();this.Z31DateStart=gx.date.nullDate();this.O31DateStart=gx.date.nullDate();this.A32DateFinish=gx.date.nullDate();this.Z32DateFinish=gx.date.nullDate();this.O32DateFinish=gx.date.nullDate();this.A40000PromotionPhoto_GXI="";this.A30PromotionPhoto="";this.Z30PromotionPhoto="";this.O30PromotionPhoto="";this.A15PromotionId=0;this.A29PromotionDescription="";this.A31DateStart=gx.date.nullDate();this.A32DateFinish=gx.date.nullDate();this.A30PromotionPhoto="";this.A40000PromotionPhoto_GXI="";this.Events={e151n2_client:["ENTER",!0],e161n2_client:["CANCEL",!0],e111n1_client:["'DOUPDATE'",!1],e121n1_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A15PromotionId",fld:"PROMOTIONID",pic:"ZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A15PromotionId",fld:"PROMOTIONID",pic:"ZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A15PromotionId",fld:"PROMOTIONID",pic:"ZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_PROMOTIONID=[[],[]];this.Initialize()})