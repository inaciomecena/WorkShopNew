gx.evt.autoSkip=!1;gx.define("country",!1,function(){this.ServerClass="country";this.PackageName="GeneXus.Programs";this.ServerFullClass="country.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7CountryId=gx.fn.getIntegerValue("vCOUNTRYID",".");this.A40000CountryFlag_GXI=gx.fn.getControlValue("COUNTRYFLAG_GXI");this.AV11Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Countryid=function(){return this.validCliEvt("Valid_Countryid",0,function(){try{var n=gx.util.balloon.getNew("COUNTRYID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Countryname=function(){return this.validSrvEvt("Valid_Countryname",0).then(function(n){return n}.closure(this))};this.e12032_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13033_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14033_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53];this.GXLastCtrlId=53;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15033_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16033_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17033_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18033_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19033_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Countryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYID",gxz:"Z8CountryId",gxold:"O8CountryId",gxvar:"A8CountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z8CountryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COUNTRYID",gx.O.A8CountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8CountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COUNTRYID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Countryname,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",gxz:"Z9CountryName",gxold:"O9CountryName",gxvar:"A9CountryName",ucs:[],op:[39],ip:[34,39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z9CountryName=n)},v2c:function(){gx.fn.setControlValue("COUNTRYNAME",gx.O.A9CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9CountryName=this.val())},val:function(){return gx.fn.getControlValue("COUNTRYNAME")},nac:gx.falseFn};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYFLAG",gxz:"Z17CountryFlag",gxold:"O17CountryFlag",gxvar:"A17CountryFlag",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A17CountryFlag=n)},v2z:function(n){n!==undefined&&(gx.O.Z17CountryFlag=n)},v2c:function(){gx.fn.setMultimediaValue("COUNTRYFLAG",gx.O.A17CountryFlag,gx.O.A40000CountryFlag_GXI)},c2v:function(){gx.O.A40000CountryFlag_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A17CountryFlag=this.val())},val:function(){return gx.fn.getBlobValue("COUNTRYFLAG")},val_GXI:function(){return gx.fn.getControlValue("COUNTRYFLAG_GXI")},gxvar_GXI:"A40000CountryFlag_GXI",nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"BTN_ENTER",grid:0,evt:"e13033_client",std:"ENTER"};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTN_CANCEL",grid:0,evt:"e14033_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"BTN_DELETE",grid:0,evt:"e20033_client",std:"DELETE"};this.A8CountryId=0;this.Z8CountryId=0;this.O8CountryId=0;this.A9CountryName="";this.Z9CountryName="";this.O9CountryName="";this.A40000CountryFlag_GXI="";this.A17CountryFlag="";this.Z17CountryFlag="";this.O17CountryFlag="";this.A40000CountryFlag_GXI="";this.AV11Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7CountryId=0;this.AV10WebSession={};this.A8CountryId=0;this.A9CountryName="";this.A17CountryFlag="";this.Gx_mode="";this.Events={e12032_client:["AFTER TRN",!0],e13033_client:["ENTER",!0],e14033_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7CountryId",fld:"vCOUNTRYID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7CountryId",fld:"vCOUNTRYID",pic:"ZZZ9",hsh:!0},{av:"A8CountryId",fld:"COUNTRYID",pic:"ZZZ9"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_COUNTRYID=[[],[]];this.EvtParms.VALID_COUNTRYNAME=[[{av:"A9CountryName",fld:"COUNTRYNAME",pic:""},{av:"A8CountryId",fld:"COUNTRYID",pic:"ZZZ9"}],[]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7CountryId","vCOUNTRYID",0,"int",4,0);this.setVCMap("A40000CountryFlag_GXI","COUNTRYFLAG_GXI",0,"svchar",2048,0);this.setVCMap("AV11Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.country)})