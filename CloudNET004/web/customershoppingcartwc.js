gx.evt.autoSkip=!1;gx.define("customershoppingcartwc",!0,function(n){var t,i;this.ServerClass="customershoppingcartwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="customershoppingcartwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6CustomerId=gx.fn.getIntegerValue("vCUSTOMERID",".");this.AV6CustomerId=gx.fn.getIntegerValue("vCUSTOMERID",".")};this.Valid_Shoppingcartid=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Shoppingcartid",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("SHOPPINGCARTID",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Shoppingcartdate=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Shoppingcartdate",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("SHOPPINGCARTDATE",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e111f2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e141f2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e151f2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,19,21,22,23,24,25,26,27,28,29,30];this.GXLastCtrlId=30;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",20,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"customershoppingcartwc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(16,21,"SHOPPINGCARTID","Cart Id","","ShoppingCartId","int",0,"px",4,4,"right",null,[],16,"ShoppingCartId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(33,22,"SHOPPINGCARTDATE","Cart Date","","ShoppingCartDate","date",0,"px",8,8,"right",null,[],33,"ShoppingCartDate",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");i.addSingleLineEdit(38,23,"SHOPPINGCARTDATEDELIVERY","Date Delivery","","ShoppingCartDateDelivery","date",0,"px",8,8,"right",null,[],38,"ShoppingCartDateDelivery",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(34,24,"SHOPPINGCARTFINALPRICE","Final","","ShoppingCartFinalPrice","decimal",0,"px",13,13,"right",null,[],34,"ShoppingCartFinalPrice",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit("Update",25,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");i.addSingleLineEdit("Delete",26,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLETOP",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"BTNINSERT",grid:0,evt:"e111f2_client"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"GRIDCELL",grid:0};t[14]={id:14,fld:"GRIDTABLE",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[21]={id:21,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Shoppingcartid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTID",gxz:"Z16ShoppingCartId",gxold:"O16ShoppingCartId",gxvar:"A16ShoppingCartId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A16ShoppingCartId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z16ShoppingCartId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SHOPPINGCARTID",n||gx.fn.currentGridRowImpl(20),gx.O.A16ShoppingCartId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16ShoppingCartId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SHOPPINGCARTID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[22]={id:22,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Shoppingcartdate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTDATE",gxz:"Z33ShoppingCartDate",gxold:"O33ShoppingCartDate",gxvar:"A33ShoppingCartDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A33ShoppingCartDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z33ShoppingCartDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SHOPPINGCARTDATE",n||gx.fn.currentGridRowImpl(20),gx.O.A33ShoppingCartDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A33ShoppingCartDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SHOPPINGCARTDATE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[23]={id:23,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTDATEDELIVERY",gxz:"Z38ShoppingCartDateDelivery",gxold:"O38ShoppingCartDateDelivery",gxvar:"A38ShoppingCartDateDelivery",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A38ShoppingCartDateDelivery=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z38ShoppingCartDateDelivery=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("SHOPPINGCARTDATEDELIVERY",n||gx.fn.currentGridRowImpl(20),gx.O.A38ShoppingCartDateDelivery,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A38ShoppingCartDateDelivery=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("SHOPPINGCARTDATEDELIVERY",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"decimal",len:10,dec:2,sign:!1,pic:"R$ ZZZZZZ9.99",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SHOPPINGCARTFINALPRICE",gxz:"Z34ShoppingCartFinalPrice",gxold:"O34ShoppingCartFinalPrice",gxvar:"A34ShoppingCartFinalPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A34ShoppingCartFinalPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z34ShoppingCartFinalPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("SHOPPINGCARTFINALPRICE",n||gx.fn.currentGridRowImpl(20),gx.O.A34ShoppingCartFinalPrice,2,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A34ShoppingCartFinalPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("SHOPPINGCARTFINALPRICE",n||gx.fn.currentGridRowImpl(20),".",",")},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[26]={id:26,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"",grid:0};t[30]={id:30,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CUSTOMERID",gxz:"Z11CustomerId",gxold:"O11CustomerId",gxvar:"A11CustomerId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A11CustomerId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z11CustomerId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CUSTOMERID",gx.O.A11CustomerId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A11CustomerId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CUSTOMERID",".")},nac:gx.falseFn};this.declareDomainHdlr(30,function(){});this.Z16ShoppingCartId=0;this.O16ShoppingCartId=0;this.Z33ShoppingCartDate=gx.date.nullDate();this.O33ShoppingCartDate=gx.date.nullDate();this.Z38ShoppingCartDateDelivery=gx.date.nullDate();this.O38ShoppingCartDateDelivery=gx.date.nullDate();this.Z34ShoppingCartFinalPrice=0;this.O34ShoppingCartFinalPrice=0;this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.A11CustomerId=0;this.Z11CustomerId=0;this.O11CustomerId=0;this.A11CustomerId=0;this.AV6CustomerId=0;this.A16ShoppingCartId=0;this.A33ShoppingCartDate=gx.date.nullDate();this.A38ShoppingCartDateDelivery=gx.date.nullDate();this.A34ShoppingCartFinalPrice=0;this.AV12Update="";this.AV13Delete="";this.Events={e111f2_client:["'DOINSERT'",!0],e141f2_client:["ENTER",!0],e151f2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CustomerId",fld:"vCUSTOMERID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A16ShoppingCartId",fld:"SHOPPINGCARTID",pic:"ZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("SHOPPINGCARTDATE","Link")',ctrl:"SHOPPINGCARTDATE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A16ShoppingCartId",fld:"SHOPPINGCARTID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CustomerId",fld:"vCUSTOMERID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CustomerId",fld:"vCUSTOMERID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CustomerId",fld:"vCUSTOMERID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CustomerId",fld:"vCUSTOMERID",pic:"ZZZ9"},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.VALID_SHOPPINGCARTID=[[],[]];this.EvtParms.VALID_SHOPPINGCARTDATE=[[],[]];this.setVCMap("AV6CustomerId","vCUSTOMERID",0,"int",4,0);this.setVCMap("AV6CustomerId","vCUSTOMERID",0,"int",4,0);this.setVCMap("AV6CustomerId","vCUSTOMERID",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6CustomerId"});i.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6CustomerId"});i.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})