gx.evt.autoSkip=!1;gx.define("categoryproductwc",!0,function(n){var t,i;this.ServerClass="categoryproductwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="categoryproductwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6CategoryId=gx.fn.getIntegerValue("vCATEGORYID",".");this.AV6CategoryId=gx.fn.getIntegerValue("vCATEGORYID",".")};this.Valid_Productcountryid=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Productcountryid",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("PRODUCTCOUNTRYID",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Sellerid=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Sellerid",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("SELLERID",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Countryid=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Countryid",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("COUNTRYID",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e111b2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e141b2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e151b2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,19,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38];this.GXLastCtrlId=38;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",20,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"categoryproductwc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Novo registro",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(12,21,"PRODUCTID","Id","","ProductId","int",0,"px",4,4,"right",null,[],12,"ProductId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(13,22,"PRODUCTNAME","do Produto","","ProductName","char",0,"px",20,20,"left",null,[],13,"ProductName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");i.addSingleLineEdit(26,23,"PRODUCTDESCRIPTION","do Produto","","ProductDescription","char",0,"px",50,50,"left",null,[],26,"ProductDescription",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(27,24,"PRODUCTPRICE","Preço","","ProductPrice","decimal",0,"px",11,11,"right",null,[],27,"ProductPrice",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addBitmap(28,"PRODUCTPHOTO",25,0,"px",17,"px",null,"","Foto","ImageAttribute","WWColumn WWOptionalColumn");i.addSingleLineEdit(14,26,"PRODUCTCOUNTRYID","ID","","ProductCountryID","int",0,"px",4,4,"right",null,[],14,"ProductCountryID",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(39,27,"PRODUCTCOUNTRYNAME","Nome","","ProductCountryName","char",0,"px",20,20,"left",null,[],39,"ProductCountryName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(10,28,"SELLERID","Vendedor Id","","SellerId","int",0,"px",4,4,"right",null,[],10,"SellerId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(18,29,"SELLERNAME","Vendedor Nome","","SellerName","char",0,"px",20,20,"left",null,[],18,"SellerName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addBitmap(19,"SELLERPHOTO",30,0,"px",17,"px",null,"","Foto","ImageAttribute","WWColumn WWOptionalColumn");i.addSingleLineEdit(8,31,"COUNTRYID","País Id","","CountryId","int",0,"px",4,4,"right",null,[],8,"CountryId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(9,32,"COUNTRYNAME","País","","CountryName","char",0,"px",20,20,"left",null,[],9,"CountryName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit("Update",33,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");i.addSingleLineEdit("Delete",34,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLETOP",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"BTNINSERT",grid:0,evt:"e111b2_client"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"GRIDCELL",grid:0};t[14]={id:14,fld:"GRIDTABLE",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[21]={id:21,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTID",gxz:"Z12ProductId",gxold:"O12ProductId",gxvar:"A12ProductId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A12ProductId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12ProductId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTID",n||gx.fn.currentGridRowImpl(20),gx.O.A12ProductId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12ProductId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[22]={id:22,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",gxz:"Z13ProductName",gxold:"O13ProductName",gxvar:"A13ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A13ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z13ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A13ProductName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A13ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[23]={id:23,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTDESCRIPTION",gxz:"Z26ProductDescription",gxold:"O26ProductDescription",gxvar:"A26ProductDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A26ProductDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z26ProductDescription=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTDESCRIPTION",n||gx.fn.currentGridRowImpl(20),gx.O.A26ProductDescription,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A26ProductDescription=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTDESCRIPTION",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"decimal",len:8,dec:2,sign:!1,pic:"R$ ZZZZ9.99",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPRICE",gxz:"Z27ProductPrice",gxold:"O27ProductPrice",gxvar:"A27ProductPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27ProductPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z27ProductPrice=gx.fn.toDecimalValue(n,".",","))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(20),gx.O.A27ProductPrice,2,",")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27ProductPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(20),".",",")},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPHOTO",gxz:"Z28ProductPhoto",gxold:"O28ProductPhoto",gxvar:"A28ProductPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A28ProductPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z28ProductPhoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("PRODUCTPHOTO",n||gx.fn.currentGridRowImpl(20),gx.O.A28ProductPhoto,gx.O.A40000ProductPhoto_GXI)},c2v:function(n){gx.O.A40000ProductPhoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A28ProductPhoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTPHOTO",n||gx.fn.currentGridRowImpl(20))},val_GXI:function(n){return gx.fn.getGridControlValue("PRODUCTPHOTO_GXI",n||gx.fn.currentGridRowImpl(20))},gxvar_GXI:"A40000ProductPhoto_GXI",nac:gx.falseFn};t[26]={id:26,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Productcountryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTCOUNTRYID",gxz:"Z14ProductCountryID",gxold:"O14ProductCountryID",gxvar:"A14ProductCountryID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A14ProductCountryID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z14ProductCountryID=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTCOUNTRYID",n||gx.fn.currentGridRowImpl(20),gx.O.A14ProductCountryID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A14ProductCountryID=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTCOUNTRYID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTCOUNTRYNAME",gxz:"Z39ProductCountryName",gxold:"O39ProductCountryName",gxvar:"A39ProductCountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A39ProductCountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z39ProductCountryName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTCOUNTRYNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A39ProductCountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A39ProductCountryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTCOUNTRYNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Sellerid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERID",gxz:"Z10SellerId",gxold:"O10SellerId",gxvar:"A10SellerId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A10SellerId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z10SellerId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("SELLERID",n||gx.fn.currentGridRowImpl(20),gx.O.A10SellerId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A10SellerId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("SELLERID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[29]={id:29,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERNAME",gxz:"Z18SellerName",gxold:"O18SellerName",gxvar:"A18SellerName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A18SellerName=n)},v2z:function(n){n!==undefined&&(gx.O.Z18SellerName=n)},v2c:function(n){gx.fn.setGridControlValue("SELLERNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A18SellerName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A18SellerName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SELLERNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[30]={id:30,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SELLERPHOTO",gxz:"Z19SellerPhoto",gxold:"O19SellerPhoto",gxvar:"A19SellerPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A19SellerPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z19SellerPhoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("SELLERPHOTO",n||gx.fn.currentGridRowImpl(20),gx.O.A19SellerPhoto,gx.O.A40001SellerPhoto_GXI)},c2v:function(n){gx.O.A40001SellerPhoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A19SellerPhoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("SELLERPHOTO",n||gx.fn.currentGridRowImpl(20))},val_GXI:function(n){return gx.fn.getGridControlValue("SELLERPHOTO_GXI",n||gx.fn.currentGridRowImpl(20))},gxvar_GXI:"A40001SellerPhoto_GXI",nac:gx.falseFn};t[31]={id:31,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Countryid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYID",gxz:"Z8CountryId",gxold:"O8CountryId",gxvar:"A8CountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A8CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z8CountryId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("COUNTRYID",n||gx.fn.currentGridRowImpl(20),gx.O.A8CountryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8CountryId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("COUNTRYID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[32]={id:32,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",gxz:"Z9CountryName",gxold:"O9CountryName",gxvar:"A9CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A9CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z9CountryName=n)},v2c:function(n){gx.fn.setGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A9CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A9CountryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[33]={id:33,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV13Update",gxold:"OV13Update",gxvar:"AV13Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20),gx.O.AV13Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[34]={id:34,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV14Delete",gxold:"OV14Delete",gxvar:"AV14Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20),gx.O.AV14Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CATEGORYID",gxz:"Z6CategoryId",gxold:"O6CategoryId",gxvar:"A6CategoryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A6CategoryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z6CategoryId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CATEGORYID",gx.O.A6CategoryId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A6CategoryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CATEGORYID",".")},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});this.Z12ProductId=0;this.O12ProductId=0;this.Z13ProductName="";this.O13ProductName="";this.Z26ProductDescription="";this.O26ProductDescription="";this.Z27ProductPrice=0;this.O27ProductPrice=0;this.Z28ProductPhoto="";this.O28ProductPhoto="";this.Z14ProductCountryID=0;this.O14ProductCountryID=0;this.Z39ProductCountryName="";this.O39ProductCountryName="";this.Z10SellerId=0;this.O10SellerId=0;this.Z18SellerName="";this.O18SellerName="";this.Z19SellerPhoto="";this.O19SellerPhoto="";this.Z8CountryId=0;this.O8CountryId=0;this.Z9CountryName="";this.O9CountryName="";this.ZV13Update="";this.OV13Update="";this.ZV14Delete="";this.OV14Delete="";this.A6CategoryId=0;this.Z6CategoryId=0;this.O6CategoryId=0;this.A6CategoryId=0;this.A40000ProductPhoto_GXI="";this.A40001SellerPhoto_GXI="";this.AV6CategoryId=0;this.A12ProductId=0;this.A13ProductName="";this.A26ProductDescription="";this.A27ProductPrice=0;this.A28ProductPhoto="";this.A14ProductCountryID=0;this.A39ProductCountryName="";this.A10SellerId=0;this.A18SellerName="";this.A19SellerPhoto="";this.A8CountryId=0;this.A9CountryName="";this.AV13Update="";this.AV14Delete="";this.Events={e111b2_client:["'DOINSERT'",!0],e141b2_client:["ENTER",!0],e151b2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CategoryId",fld:"vCATEGORYID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A12ProductId",fld:"PRODUCTID",pic:"ZZZ9",hsh:!0},{av:"A10SellerId",fld:"SELLERID",pic:"ZZZ9"},{av:"A8CountryId",fld:"COUNTRYID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("PRODUCTNAME","Link")',ctrl:"PRODUCTNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("SELLERNAME","Link")',ctrl:"SELLERNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("COUNTRYNAME","Link")',ctrl:"COUNTRYNAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A12ProductId",fld:"PRODUCTID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CategoryId",fld:"vCATEGORYID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CategoryId",fld:"vCATEGORYID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CategoryId",fld:"vCATEGORYID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6CategoryId",fld:"vCATEGORYID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.VALID_PRODUCTCOUNTRYID=[[],[]];this.EvtParms.VALID_SELLERID=[[],[]];this.EvtParms.VALID_COUNTRYID=[[],[]];this.setVCMap("AV6CategoryId","vCATEGORYID",0,"int",4,0);this.setVCMap("AV6CategoryId","vCATEGORYID",0,"int",4,0);this.setVCMap("AV6CategoryId","vCATEGORYID",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6CategoryId"});i.addRefreshingVar({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6CategoryId"});i.addRefreshingParm({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})