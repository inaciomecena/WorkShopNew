gx.evt.autoSkip=!1;gx.define("sellergeneral",!0,function(n){this.ServerClass="sellergeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="sellergeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Sellerid=function(){return this.validCliEvt("Valid_Sellerid",0,function(){try{var n=gx.util.balloon.getNew("SELLERID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Countryid=function(){return this.validCliEvt("Valid_Countryid",0,function(){try{var n=gx.util.balloon.getNew("COUNTRYID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e130r2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140r2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32];this.GXLastCtrlId=32;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"ATTRIBUTESTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Sellerid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERID",gxz:"Z10SellerId",gxold:"O10SellerId",gxvar:"A10SellerId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A10SellerId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z10SellerId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("SELLERID",gx.O.A10SellerId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A10SellerId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("SELLERID",".")},nac:gx.falseFn};this.declareDomainHdlr(11,function(){});t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERNAME",gxz:"Z18SellerName",gxold:"O18SellerName",gxvar:"A18SellerName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A18SellerName=n)},v2z:function(n){n!==undefined&&(gx.O.Z18SellerName=n)},v2c:function(){gx.fn.setControlValue("SELLERNAME",gx.O.A18SellerName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A18SellerName=this.val())},val:function(){return gx.fn.getControlValue("SELLERNAME")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});t[17]={id:17,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Countryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYID",gxz:"Z8CountryId",gxold:"O8CountryId",gxvar:"A8CountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z8CountryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("COUNTRYID",gx.O.A8CountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8CountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("COUNTRYID",".")},nac:gx.falseFn};this.declareDomainHdlr(21,function(){});t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",gxz:"Z9CountryName",gxold:"O9CountryName",gxvar:"A9CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z9CountryName=n)},v2c:function(){gx.fn.setControlValue("COUNTRYNAME",gx.O.A9CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9CountryName=this.val())},val:function(){return gx.fn.getControlValue("COUNTRYNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"IMAGESTABLE",grid:0};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,lvl:0,type:"bits",len:1024,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERPHOTO",gxz:"Z19SellerPhoto",gxold:"O19SellerPhoto",gxvar:"A19SellerPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A19SellerPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z19SellerPhoto=n)},v2c:function(){gx.fn.setMultimediaValue("SELLERPHOTO",gx.O.A19SellerPhoto,gx.O.A40000SellerPhoto_GXI)},c2v:function(){gx.O.A40000SellerPhoto_GXI=this.val_GXI();this.val()!==undefined&&(gx.O.A19SellerPhoto=this.val())},val:function(){return gx.fn.getBlobValue("SELLERPHOTO")},val_GXI:function(){return gx.fn.getControlValue("SELLERPHOTO_GXI")},gxvar_GXI:"A40000SellerPhoto_GXI",nac:gx.falseFn};this.A10SellerId=0;this.Z10SellerId=0;this.O10SellerId=0;this.A18SellerName="";this.Z18SellerName="";this.O18SellerName="";this.A8CountryId=0;this.Z8CountryId=0;this.O8CountryId=0;this.A9CountryName="";this.Z9CountryName="";this.O9CountryName="";this.A40000SellerPhoto_GXI="";this.A19SellerPhoto="";this.Z19SellerPhoto="";this.O19SellerPhoto="";this.A10SellerId=0;this.A18SellerName="";this.A8CountryId=0;this.A9CountryName="";this.A19SellerPhoto="";this.A40000SellerPhoto_GXI="";this.Events={e130r2_client:["ENTER",!0],e140r2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"A10SellerId",fld:"SELLERID",pic:"ZZZ9"},{av:"A8CountryId",fld:"COUNTRYID",pic:"ZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_SELLERID=[[],[]];this.EvtParms.VALID_COUNTRYID=[[],[]];this.Initialize()})