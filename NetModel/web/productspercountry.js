gx.evt.autoSkip=!1;gx.define("productspercountry",!1,function(){var n,t;this.ServerClass="productspercountry";this.PackageName="GeneXus.Programs";this.ServerFullClass="productspercountry.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A13ProductName=gx.fn.getControlValue("PRODUCTNAME");this.A14ProductCountryID=gx.fn.getIntegerValue("PRODUCTCOUNTRYID",".");this.A28ProductPhoto=gx.fn.getBlobValue("PRODUCTPHOTO");this.A40000ProductPhoto_GXI=gx.fn.getControlValue("PRODUCTPHOTO_GXI");this.A27ProductPrice=gx.fn.getDecimalValue("PRODUCTPRICE",".",",");this.A39ProductCountryName=gx.fn.getControlValue("PRODUCTCOUNTRYNAME");this.A7CategoryName=gx.fn.getControlValue("CATEGORYNAME");this.A19SellerPhoto=gx.fn.getBlobValue("SELLERPHOTO");this.A40001SellerPhoto_GXI=gx.fn.getControlValue("SELLERPHOTO_GXI")};this.e120n2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e130n2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,29];this.GXLastCtrlId=29;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",23,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"productspercountry",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addSingleLineEdit("Productname",24,"vPRODUCTNAME","Product Name","","ProductName","char",0,"px",20,20,"left",null,[],"Productname","ProductName",!0,0,!1,!1,"",0,"");t.addBitmap("&Productphoto","vPRODUCTPHOTO",25,0,"px",17,"px",null,"","Product Photo","ImageAttribute","");t.addSingleLineEdit("Productprice",26,"vPRODUCTPRICE","Product Price","","ProductPrice","decimal",0,"px",10,10,"right",null,[],"Productprice","ProductPrice",!0,2,!1,!1,"",0,"");t.addSingleLineEdit("Productcountryname",27,"vPRODUCTCOUNTRYNAME","Product Country Name","","ProductCountryName","char",0,"px",20,20,"left",null,[],"Productcountryname","ProductCountryName",!0,0,!1,!1,"",0,"");t.addSingleLineEdit("Categoryname",28,"vCATEGORYNAME","Category Name","","CategoryName","char",0,"px",20,20,"left",null,[],"Categoryname","CategoryName",!0,0,!1,!1,"",0,"");t.addBitmap("&Sellerphoto","vSELLERPHOTO",29,0,"px",17,"px",null,"","Seller Photo","ImageAttribute","");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE1",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLE2",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODUCTCOUNTRYID",gxz:"ZV5ProductCountryId",gxold:"OV5ProductCountryId",gxvar:"AV5ProductCountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV5ProductCountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5ProductCountryId=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vPRODUCTCOUNTRYID",gx.O.AV5ProductCountryId)},c2v:function(){this.val()!==undefined&&(gx.O.AV5ProductCountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vPRODUCTCOUNTRYID",".")},nac:gx.falseFn};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"TABLE3",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"",grid:0};n[24]={id:24,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:23,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODUCTNAME",gxz:"ZV7ProductName",gxold:"OV7ProductName",gxvar:"AV7ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV7ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("vPRODUCTNAME",n||gx.fn.currentGridRowImpl(23),gx.O.AV7ProductName,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV7ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vPRODUCTNAME",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn};n[25]={id:25,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:23,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODUCTPHOTO",gxz:"ZV8ProductPhoto",gxold:"OV8ProductPhoto",gxvar:"AV8ProductPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV8ProductPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8ProductPhoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vPRODUCTPHOTO",n||gx.fn.currentGridRowImpl(23),gx.O.AV8ProductPhoto,gx.O.AV15Productphoto_GXI)},c2v:function(n){gx.O.AV15Productphoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV8ProductPhoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vPRODUCTPHOTO",n||gx.fn.currentGridRowImpl(23))},val_GXI:function(n){return gx.fn.getGridControlValue("vPRODUCTPHOTO_GXI",n||gx.fn.currentGridRowImpl(23))},gxvar_GXI:"AV15Productphoto_GXI",nac:gx.falseFn};n[26]={id:26,lvl:2,type:"decimal",len:8,dec:2,sign:!1,pic:"$ ZZZZ9.99",ro:1,isacc:0,grid:23,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODUCTPRICE",gxz:"ZV9ProductPrice",gxold:"OV9ProductPrice",gxvar:"AV9ProductPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV9ProductPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.ZV9ProductPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("vPRODUCTPRICE",n||gx.fn.currentGridRowImpl(23),gx.O.AV9ProductPrice,2,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV9ProductPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("vPRODUCTPRICE",n||gx.fn.currentGridRowImpl(23),".",",")},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:23,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPRODUCTCOUNTRYNAME",gxz:"ZV10ProductCountryName",gxold:"OV10ProductCountryName",gxvar:"AV10ProductCountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV10ProductCountryName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10ProductCountryName=n)},v2c:function(n){gx.fn.setGridControlValue("vPRODUCTCOUNTRYNAME",n||gx.fn.currentGridRowImpl(23),gx.O.AV10ProductCountryName,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV10ProductCountryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vPRODUCTCOUNTRYNAME",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:23,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCATEGORYNAME",gxz:"ZV11CategoryName",gxold:"OV11CategoryName",gxvar:"AV11CategoryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11CategoryName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11CategoryName=n)},v2c:function(n){gx.fn.setGridControlValue("vCATEGORYNAME",n||gx.fn.currentGridRowImpl(23),gx.O.AV11CategoryName,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11CategoryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vCATEGORYNAME",n||gx.fn.currentGridRowImpl(23))},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:23,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSELLERPHOTO",gxz:"ZV6SellerPhoto",gxold:"OV6SellerPhoto",gxvar:"AV6SellerPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV6SellerPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6SellerPhoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vSELLERPHOTO",n||gx.fn.currentGridRowImpl(23),gx.O.AV6SellerPhoto,gx.O.AV16Sellerphoto_GXI)},c2v:function(n){gx.O.AV16Sellerphoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV6SellerPhoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vSELLERPHOTO",n||gx.fn.currentGridRowImpl(23))},val_GXI:function(n){return gx.fn.getGridControlValue("vSELLERPHOTO_GXI",n||gx.fn.currentGridRowImpl(23))},gxvar_GXI:"AV16Sellerphoto_GXI",nac:gx.falseFn};this.AV5ProductCountryId=0;this.ZV5ProductCountryId=0;this.OV5ProductCountryId=0;this.ZV7ProductName="";this.OV7ProductName="";this.ZV8ProductPhoto="";this.OV8ProductPhoto="";this.ZV9ProductPrice=0;this.OV9ProductPrice=0;this.ZV10ProductCountryName="";this.OV10ProductCountryName="";this.ZV11CategoryName="";this.OV11CategoryName="";this.ZV6SellerPhoto="";this.OV6SellerPhoto="";this.AV5ProductCountryId=0;this.AV7ProductName="";this.AV8ProductPhoto="";this.AV9ProductPrice=0;this.AV10ProductCountryName="";this.AV11CategoryName="";this.AV6SellerPhoto="";this.A40000ProductPhoto_GXI="";this.A40001SellerPhoto_GXI="";this.A14ProductCountryID=0;this.A28ProductPhoto="";this.A27ProductPrice=0;this.A39ProductCountryName="";this.A7CategoryName="";this.A19SellerPhoto="";this.A13ProductName="";this.A6CategoryId=0;this.A10SellerId=0;this.Events={e120n2_client:["ENTER",!0],e130n2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"A13ProductName",fld:"PRODUCTNAME",pic:""},{av:"A14ProductCountryID",fld:"PRODUCTCOUNTRYID",pic:"ZZZ9"},{av:"A28ProductPhoto",fld:"PRODUCTPHOTO",pic:""},{av:"A40000ProductPhoto_GXI",fld:"PRODUCTPHOTO_GXI",pic:""},{av:"A27ProductPrice",fld:"PRODUCTPRICE",pic:"$ ZZZZ9.99"},{av:"A39ProductCountryName",fld:"PRODUCTCOUNTRYNAME",pic:""},{av:"A7CategoryName",fld:"CATEGORYNAME",pic:""},{av:"A19SellerPhoto",fld:"SELLERPHOTO",pic:""},{av:"A40001SellerPhoto_GXI",fld:"SELLERPHOTO_GXI",pic:""},{ctrl:"vPRODUCTCOUNTRYID"},{av:"AV5ProductCountryId",fld:"vPRODUCTCOUNTRYID",pic:"ZZZ9"}],[{ctrl:"vPRODUCTCOUNTRYID"},{av:"AV5ProductCountryId",fld:"vPRODUCTCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms.ENTER=[[{ctrl:"vPRODUCTCOUNTRYID"},{av:"AV5ProductCountryId",fld:"vPRODUCTCOUNTRYID",pic:"ZZZ9"}],[{ctrl:"vPRODUCTCOUNTRYID"},{av:"AV5ProductCountryId",fld:"vPRODUCTCOUNTRYID",pic:"ZZZ9"}]];this.setVCMap("A13ProductName","PRODUCTNAME",0,"char",20,0);this.setVCMap("A14ProductCountryID","PRODUCTCOUNTRYID",0,"int",4,0);this.setVCMap("A28ProductPhoto","PRODUCTPHOTO",0,"bits",1024,0);this.setVCMap("A40000ProductPhoto_GXI","PRODUCTPHOTO_GXI",0,"svchar",2048,0);this.setVCMap("A27ProductPrice","PRODUCTPRICE",0,"decimal",8,2);this.setVCMap("A39ProductCountryName","PRODUCTCOUNTRYNAME",0,"char",20,0);this.setVCMap("A7CategoryName","CATEGORYNAME",0,"char",20,0);this.setVCMap("A19SellerPhoto","SELLERPHOTO",0,"bits",1024,0);this.setVCMap("A40001SellerPhoto_GXI","SELLERPHOTO_GXI",0,"svchar",2048,0);this.setVCMap("A13ProductName","PRODUCTNAME",0,"char",20,0);this.setVCMap("A14ProductCountryID","PRODUCTCOUNTRYID",0,"int",4,0);this.setVCMap("A28ProductPhoto","PRODUCTPHOTO",0,"bits",1024,0);this.setVCMap("A40000ProductPhoto_GXI","PRODUCTPHOTO_GXI",0,"svchar",2048,0);this.setVCMap("A27ProductPrice","PRODUCTPRICE",0,"decimal",8,2);this.setVCMap("A39ProductCountryName","PRODUCTCOUNTRYNAME",0,"char",20,0);this.setVCMap("A7CategoryName","CATEGORYNAME",0,"char",20,0);this.setVCMap("A19SellerPhoto","SELLERPHOTO",0,"bits",1024,0);this.setVCMap("A40001SellerPhoto_GXI","SELLERPHOTO_GXI",0,"svchar",2048,0);t.addRefreshingVar({rfrVar:"A13ProductName"});t.addRefreshingVar({rfrVar:"A14ProductCountryID"});t.addRefreshingVar(this.GXValidFnc[17]);t.addRefreshingVar({rfrVar:"A28ProductPhoto"});t.addRefreshingVar({rfrVar:"A40000ProductPhoto_GXI"});t.addRefreshingVar({rfrVar:"A27ProductPrice"});t.addRefreshingVar({rfrVar:"A39ProductCountryName"});t.addRefreshingVar({rfrVar:"A7CategoryName"});t.addRefreshingVar({rfrVar:"A19SellerPhoto"});t.addRefreshingVar({rfrVar:"A40001SellerPhoto_GXI"});t.addRefreshingParm({rfrVar:"A13ProductName"});t.addRefreshingParm({rfrVar:"A14ProductCountryID"});t.addRefreshingParm(this.GXValidFnc[17]);t.addRefreshingParm({rfrVar:"A28ProductPhoto"});t.addRefreshingParm({rfrVar:"A40000ProductPhoto_GXI"});t.addRefreshingParm({rfrVar:"A27ProductPrice"});t.addRefreshingParm({rfrVar:"A39ProductCountryName"});t.addRefreshingParm({rfrVar:"A7CategoryName"});t.addRefreshingParm({rfrVar:"A19SellerPhoto"});t.addRefreshingParm({rfrVar:"A40001SellerPhoto_GXI"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.productspercountry)})