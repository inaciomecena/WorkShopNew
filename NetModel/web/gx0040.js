gx.evt.autoSkip=!1;gx.define("gx0040",!1,function(){var n,t;this.ServerClass="gx0040";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0040.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9pSellerId=gx.fn.getIntegerValue("vPSELLERID",".")};this.e140v1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110v1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("SELLERIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("SELLERIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCSELLERID","Visible",!0)):(gx.fn.setCtrlProperty("SELLERIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCSELLERID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("SELLERIDFILTERCONTAINER","Class")',ctrl:"SELLERIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCSELLERID","Visible")',ctrl:"vCSELLERID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120v1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("SELLERNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("SELLERNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCSELLERNAME","Visible",!0)):(gx.fn.setCtrlProperty("SELLERNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCSELLERNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("SELLERNAMEFILTERCONTAINER","Class")',ctrl:"SELLERNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCSELLERNAME","Visible")',ctrl:"vCSELLERNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130v1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("COUNTRYIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("COUNTRYIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCCOUNTRYID","Visible",!0)):(gx.fn.setCtrlProperty("COUNTRYIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCCOUNTRYID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("COUNTRYIDFILTERCONTAINER","Class")',ctrl:"COUNTRYIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOUNTRYID","Visible")',ctrl:"vCCOUNTRYID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e170v2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e180v1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51,52];this.GXLastCtrlId=52;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",44,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0040",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",45,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(10,46,"SELLERID","Id","","SellerId","int",0,"px",4,4,"right",null,[],10,"SellerId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(18,47,"SELLERNAME","Vendedor","","SellerName","char",0,"px",20,20,"left",null,[],18,"SellerName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addBitmap(19,"SELLERPHOTO",48,0,"px",17,"px",null,"","Foto","ImageAttribute","WWColumn OptionalColumn");t.addSingleLineEdit(8,49,"COUNTRYID","País Id","","CountryId","int",0,"px",4,4,"right",null,[],8,"CountryId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"SELLERIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLSELLERIDFILTER",format:1,grid:0,evt:"e110v1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCSELLERID",gxz:"ZV6cSellerId",gxold:"OV6cSellerId",gxvar:"AV6cSellerId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cSellerId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cSellerId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCSELLERID",gx.O.AV6cSellerId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cSellerId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCSELLERID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"SELLERNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLSELLERNAMEFILTER",format:1,grid:0,evt:"e120v1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCSELLERNAME",gxz:"ZV7cSellerName",gxold:"OV7cSellerName",gxvar:"AV7cSellerName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cSellerName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cSellerName=n)},v2c:function(){gx.fn.setControlValue("vCSELLERNAME",gx.O.AV7cSellerName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cSellerName=this.val())},val:function(){return gx.fn.getControlValue("vCSELLERNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"COUNTRYIDFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLCOUNTRYIDFILTER",format:1,grid:0,evt:"e130v1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCCOUNTRYID",gxz:"ZV8cCountryId",gxold:"OV8cCountryId",gxvar:"AV8cCountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cCountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cCountryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCCOUNTRYID",gx.O.AV8cCountryId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cCountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCCOUNTRYID",".")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"GRIDTABLE",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNTOGGLE",grid:0,evt:"e140v1_client"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[45]={id:45,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44),gx.O.AV5LinkSelection,gx.O.AV13Linkselection_GXI)},c2v:function(n){gx.O.AV13Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(44))},gxvar_GXI:"AV13Linkselection_GXI",nac:gx.falseFn};n[46]={id:46,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERID",gxz:"Z10SellerId",gxold:"O10SellerId",gxvar:"A10SellerId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A10SellerId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z10SellerId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SELLERID",n||gx.fn.currentGridRowImpl(44),gx.O.A10SellerId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A10SellerId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SELLERID",n||gx.fn.currentGridRowImpl(44),".")},nac:gx.falseFn};n[47]={id:47,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERNAME",gxz:"Z18SellerName",gxold:"O18SellerName",gxvar:"A18SellerName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A18SellerName=n)},v2z:function(n){n!==undefined&&(gx.O.Z18SellerName=n)},v2c:function(n){gx.fn.setGridControlValue("SELLERNAME",n||gx.fn.currentGridRowImpl(44),gx.O.A18SellerName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A18SellerName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SELLERNAME",n||gx.fn.currentGridRowImpl(44))},nac:gx.falseFn};n[48]={id:48,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERPHOTO",gxz:"Z19SellerPhoto",gxold:"O19SellerPhoto",gxvar:"A19SellerPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A19SellerPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z19SellerPhoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("SELLERPHOTO",n||gx.fn.currentGridRowImpl(44),gx.O.A19SellerPhoto,gx.O.A40000SellerPhoto_GXI)},c2v:function(n){gx.O.A40000SellerPhoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A19SellerPhoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SELLERPHOTO",n||gx.fn.currentGridRowImpl(44))},val_GXI:function(n){return gx.fn.getGridControlValue("SELLERPHOTO_GXI",n||gx.fn.currentGridRowImpl(44))},gxvar_GXI:"A40000SellerPhoto_GXI",nac:gx.falseFn};n[49]={id:49,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYID",gxz:"Z8CountryId",gxold:"O8CountryId",gxvar:"A8CountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A8CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z8CountryId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("COUNTRYID",n||gx.fn.currentGridRowImpl(44),gx.O.A8CountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8CountryId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("COUNTRYID",n||gx.fn.currentGridRowImpl(44),".")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"BTN_CANCEL",grid:0,evt:"e180v1_client"};this.AV6cSellerId=0;this.ZV6cSellerId=0;this.OV6cSellerId=0;this.AV7cSellerName="";this.ZV7cSellerName="";this.OV7cSellerName="";this.AV8cCountryId=0;this.ZV8cCountryId=0;this.OV8cCountryId=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z10SellerId=0;this.O10SellerId=0;this.Z18SellerName="";this.O18SellerName="";this.Z19SellerPhoto="";this.O19SellerPhoto="";this.Z8CountryId=0;this.O8CountryId=0;this.AV6cSellerId=0;this.AV7cSellerName="";this.AV8cCountryId=0;this.A40000SellerPhoto_GXI="";this.AV9pSellerId=0;this.AV5LinkSelection="";this.A10SellerId=0;this.A18SellerName="";this.A19SellerPhoto="";this.A8CountryId=0;this.Events={e170v2_client:["ENTER",!0],e180v1_client:["CANCEL",!0],e140v1_client:["'TOGGLE'",!1],e110v1_client:["LBLSELLERIDFILTER.CLICK",!1],e120v1_client:["LBLSELLERNAMEFILTER.CLICK",!1],e130v1_client:["LBLCOUNTRYIDFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cSellerId",fld:"vCSELLERID",pic:"ZZZ9"},{av:"AV7cSellerName",fld:"vCSELLERNAME",pic:""},{av:"AV8cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLSELLERIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("SELLERIDFILTERCONTAINER","Class")',ctrl:"SELLERIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("SELLERIDFILTERCONTAINER","Class")',ctrl:"SELLERIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCSELLERID","Visible")',ctrl:"vCSELLERID",prop:"Visible"}]];this.EvtParms["LBLSELLERNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("SELLERNAMEFILTERCONTAINER","Class")',ctrl:"SELLERNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("SELLERNAMEFILTERCONTAINER","Class")',ctrl:"SELLERNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCSELLERNAME","Visible")',ctrl:"vCSELLERNAME",prop:"Visible"}]];this.EvtParms["LBLCOUNTRYIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("COUNTRYIDFILTERCONTAINER","Class")',ctrl:"COUNTRYIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("COUNTRYIDFILTERCONTAINER","Class")',ctrl:"COUNTRYIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCCOUNTRYID","Visible")',ctrl:"vCCOUNTRYID",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A10SellerId",fld:"SELLERID",pic:"ZZZ9",hsh:!0}],[{av:"AV9pSellerId",fld:"vPSELLERID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cSellerId",fld:"vCSELLERID",pic:"ZZZ9"},{av:"AV7cSellerName",fld:"vCSELLERNAME",pic:""},{av:"AV8cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cSellerId",fld:"vCSELLERID",pic:"ZZZ9"},{av:"AV7cSellerName",fld:"vCSELLERNAME",pic:""},{av:"AV8cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cSellerId",fld:"vCSELLERID",pic:"ZZZ9"},{av:"AV7cSellerName",fld:"vCSELLERNAME",pic:""},{av:"AV8cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cSellerId",fld:"vCSELLERID",pic:"ZZZ9"},{av:"AV7cSellerName",fld:"vCSELLERNAME",pic:""},{av:"AV8cCountryId",fld:"vCCOUNTRYID",pic:"ZZZ9"}],[]];this.setVCMap("AV9pSellerId","vPSELLERID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0040)})