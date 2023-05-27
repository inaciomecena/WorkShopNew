using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class productspercountry : GXDataArea
   {
      public productspercountry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public productspercountry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavProductcountryid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPRODUCTCOUNTRYID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPRODUCTCOUNTRYID0N2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_23 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_23"), "."));
               nGXsfl_23_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_23_idx"), "."));
               sGXsfl_23_idx = GetPar( "sGXsfl_23_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               A13ProductName = GetPar( "ProductName");
               A14ProductCountryID = (short)(NumberUtil.Val( GetPar( "ProductCountryID"), "."));
               dynavProductcountryid.FromJSonString( GetNextPar( ));
               AV5ProductCountryId = (short)(NumberUtil.Val( GetPar( "ProductCountryId"), "."));
               A28ProductPhoto = GetPar( "ProductPhoto");
               A40000ProductPhoto_GXI = GetPar( "ProductPhoto_GXI");
               A27ProductPrice = NumberUtil.Val( GetPar( "ProductPrice"), ".");
               A39ProductCountryName = GetPar( "ProductCountryName");
               A7CategoryName = GetPar( "CategoryName");
               A19SellerPhoto = GetPar( "SellerPhoto");
               A40001SellerPhoto_GXI = GetPar( "SellerPhoto_GXI");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( A13ProductName, A14ProductCountryID, AV5ProductCountryId, A28ProductPhoto, A40000ProductPhoto_GXI, A27ProductPrice, A39ProductCountryName, A7CategoryName, A19SellerPhoto, A40001SellerPhoto_GXI) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("masterpage", "GeneXus.Programs.masterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0N2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 204480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20235262021720", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("productspercountry.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_23", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_23), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME", StringUtil.RTrim( A13ProductName));
         GxWebStd.gx_hidden_field( context, "PRODUCTCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14ProductCountryID), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTPHOTO", A28ProductPhoto);
         GxWebStd.gx_hidden_field( context, "PRODUCTPHOTO_GXI", A40000ProductPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE", StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 8, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTCOUNTRYNAME", StringUtil.RTrim( A39ProductCountryName));
         GxWebStd.gx_hidden_field( context, "CATEGORYNAME", StringUtil.RTrim( A7CategoryName));
         GxWebStd.gx_hidden_field( context, "SELLERPHOTO", A19SellerPhoto);
         GxWebStd.gx_hidden_field( context, "SELLERPHOTO_GXI", A40001SellerPhoto_GXI);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0N2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("productspercountry.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ProductsPerCountry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Produtos por País" ;
      }

      protected void WB0N0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Products Per Country", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_ProductsPerCountry.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavProductcountryid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavProductcountryid_Internalname, "Country", "col-sm-3 ", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_23_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavProductcountryid, dynavProductcountryid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5ProductCountryId), 4, 0)), 1, dynavProductcountryid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavProductcountryid.Enabled, 0, 0, 0, "em", 0, "", "", "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "", false, 0, "HLP_ProductsPerCountry.htm");
            dynavProductcountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5ProductCountryId), 4, 0));
            AssignProp("", false, dynavProductcountryid_Internalname, "Values", (string)(dynavProductcountryid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"23\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+""+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Product Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Product Photo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+""+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Product Price") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+""+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Product Country Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+""+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Category Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Seller Photo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV7ProductName));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV8ProductPhoto));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( AV9ProductPrice, 11, 2, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV10ProductCountryName));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV11CategoryName));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV6SellerPhoto));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 23 )
         {
            wbEnd = 0;
            nRC_GXsfl_23 = (int)(nGXsfl_23_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 23 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0N2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Produtos por País", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0N0( ) ;
      }

      protected void WS0N2( )
      {
         START0N2( ) ;
         EVT0N2( ) ;
      }

      protected void EVT0N2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_23_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
                              SubsflControlProps_232( ) ;
                              AV7ProductName = cgiGet( edtavProductname_Internalname);
                              AssignAttri("", false, edtavProductname_Internalname, AV7ProductName);
                              AV8ProductPhoto = cgiGet( edtavProductphoto_Internalname);
                              AssignProp("", false, edtavProductphoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV8ProductPhoto)) ? AV15Productphoto_GXI : context.convertURL( context.PathToRelativeUrl( AV8ProductPhoto))), !bGXsfl_23_Refreshing);
                              AssignProp("", false, edtavProductphoto_Internalname, "SrcSet", context.GetImageSrcSet( AV8ProductPhoto), true);
                              AV9ProductPrice = context.localUtil.CToN( cgiGet( edtavProductprice_Internalname), ",", ".");
                              AssignAttri("", false, edtavProductprice_Internalname, StringUtil.LTrimStr( AV9ProductPrice, 8, 2));
                              AV10ProductCountryName = cgiGet( edtavProductcountryname_Internalname);
                              AssignAttri("", false, edtavProductcountryname_Internalname, AV10ProductCountryName);
                              AV11CategoryName = cgiGet( edtavCategoryname_Internalname);
                              AssignAttri("", false, edtavCategoryname_Internalname, AV11CategoryName);
                              AV6SellerPhoto = cgiGet( edtavSellerphoto_Internalname);
                              AssignProp("", false, edtavSellerphoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV6SellerPhoto)) ? AV16Sellerphoto_GXI : context.convertURL( context.PathToRelativeUrl( AV6SellerPhoto))), !bGXsfl_23_Refreshing);
                              AssignProp("", false, edtavSellerphoto_Internalname, "SrcSet", context.GetImageSrcSet( AV6SellerPhoto), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E110N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0N2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavProductcountryid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvPRODUCTCOUNTRYID0N2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPRODUCTCOUNTRYID_data0N2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvPRODUCTCOUNTRYID_html0N2( )
      {
         short gxdynajaxvalue;
         GXDLVvPRODUCTCOUNTRYID_data0N2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavProductcountryid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavProductcountryid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPRODUCTCOUNTRYID_data0N2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Select Country");
         /* Using cursor H000N2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000N2_A14ProductCountryID[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H000N2_A39ProductCountryName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_232( ) ;
         while ( nGXsfl_23_idx <= nRC_GXsfl_23 )
         {
            sendrow_232( ) ;
            nGXsfl_23_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_23_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
            sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
            SubsflControlProps_232( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( string A13ProductName ,
                                        short A14ProductCountryID ,
                                        short AV5ProductCountryId ,
                                        string A28ProductPhoto ,
                                        string A40000ProductPhoto_GXI ,
                                        decimal A27ProductPrice ,
                                        string A39ProductCountryName ,
                                        string A7CategoryName ,
                                        string A19SellerPhoto ,
                                        string A40001SellerPhoto_GXI )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvPRODUCTCOUNTRYID_html0N2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavProductcountryid.ItemCount > 0 )
         {
            AV5ProductCountryId = (short)(NumberUtil.Val( dynavProductcountryid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5ProductCountryId), 4, 0))), "."));
            AssignAttri("", false, "AV5ProductCountryId", StringUtil.LTrimStr( (decimal)(AV5ProductCountryId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavProductcountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5ProductCountryId), 4, 0));
            AssignProp("", false, dynavProductcountryid_Internalname, "Values", dynavProductcountryid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 23;
         nGXsfl_23_idx = 1;
         sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
         SubsflControlProps_232( ) ;
         bGXsfl_23_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         if ( subGrid1_Islastpage != 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordcount( )-subGrid1_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
            Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_232( ) ;
            /* Execute user event: Load */
            E110N2 ();
            wbEnd = 23;
            WB0N0( ) ;
         }
         bGXsfl_23_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0N2( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         GXVvPRODUCTCOUNTRYID_html0N2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_23 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_23"), ",", "."));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E110N2( )
      {
         /* Load Routine */
         returnInSub = false;
         /* Using cursor H000N3 */
         pr_default.execute(1, new Object[] {AV5ProductCountryId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A6CategoryId = H000N3_A6CategoryId[0];
            A10SellerId = H000N3_A10SellerId[0];
            A14ProductCountryID = H000N3_A14ProductCountryID[0];
            A40000ProductPhoto_GXI = H000N3_A40000ProductPhoto_GXI[0];
            A40001SellerPhoto_GXI = H000N3_A40001SellerPhoto_GXI[0];
            A27ProductPrice = H000N3_A27ProductPrice[0];
            A39ProductCountryName = H000N3_A39ProductCountryName[0];
            A7CategoryName = H000N3_A7CategoryName[0];
            A13ProductName = H000N3_A13ProductName[0];
            A28ProductPhoto = H000N3_A28ProductPhoto[0];
            A19SellerPhoto = H000N3_A19SellerPhoto[0];
            A7CategoryName = H000N3_A7CategoryName[0];
            A40001SellerPhoto_GXI = H000N3_A40001SellerPhoto_GXI[0];
            A19SellerPhoto = H000N3_A19SellerPhoto[0];
            A39ProductCountryName = H000N3_A39ProductCountryName[0];
            AV7ProductName = A13ProductName;
            AssignAttri("", false, edtavProductname_Internalname, AV7ProductName);
            AV8ProductPhoto = A28ProductPhoto;
            AssignAttri("", false, edtavProductphoto_Internalname, AV8ProductPhoto);
            AV15Productphoto_GXI = A40000ProductPhoto_GXI;
            AV9ProductPrice = A27ProductPrice;
            AssignAttri("", false, edtavProductprice_Internalname, StringUtil.LTrimStr( AV9ProductPrice, 8, 2));
            AV10ProductCountryName = A39ProductCountryName;
            AssignAttri("", false, edtavProductcountryname_Internalname, AV10ProductCountryName);
            AV11CategoryName = A7CategoryName;
            AssignAttri("", false, edtavCategoryname_Internalname, AV11CategoryName);
            AV6SellerPhoto = A19SellerPhoto;
            AssignAttri("", false, edtavSellerphoto_Internalname, AV6SellerPhoto);
            AV16Sellerphoto_GXI = A40001SellerPhoto_GXI;
            sendrow_232( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_23_Refreshing )
            {
               DoAjaxLoad(23, Grid1Row);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0N2( ) ;
         WS0N2( ) ;
         WE0N2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023526202184", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("productspercountry.js", "?2023526202185", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_232( )
      {
         edtavProductname_Internalname = "vPRODUCTNAME_"+sGXsfl_23_idx;
         edtavProductphoto_Internalname = "vPRODUCTPHOTO_"+sGXsfl_23_idx;
         edtavProductprice_Internalname = "vPRODUCTPRICE_"+sGXsfl_23_idx;
         edtavProductcountryname_Internalname = "vPRODUCTCOUNTRYNAME_"+sGXsfl_23_idx;
         edtavCategoryname_Internalname = "vCATEGORYNAME_"+sGXsfl_23_idx;
         edtavSellerphoto_Internalname = "vSELLERPHOTO_"+sGXsfl_23_idx;
      }

      protected void SubsflControlProps_fel_232( )
      {
         edtavProductname_Internalname = "vPRODUCTNAME_"+sGXsfl_23_fel_idx;
         edtavProductphoto_Internalname = "vPRODUCTPHOTO_"+sGXsfl_23_fel_idx;
         edtavProductprice_Internalname = "vPRODUCTPRICE_"+sGXsfl_23_fel_idx;
         edtavProductcountryname_Internalname = "vPRODUCTCOUNTRYNAME_"+sGXsfl_23_fel_idx;
         edtavCategoryname_Internalname = "vCATEGORYNAME_"+sGXsfl_23_fel_idx;
         edtavSellerphoto_Internalname = "vSELLERPHOTO_"+sGXsfl_23_fel_idx;
      }

      protected void sendrow_232( )
      {
         SubsflControlProps_232( ) ;
         WB0N0( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_23_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+""+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_23_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductname_Internalname,StringUtil.RTrim( AV7ProductName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProductname_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         AV8ProductPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV8ProductPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( AV15Productphoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV8ProductPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8ProductPhoto)) ? AV15Productphoto_GXI : context.PathToRelativeUrl( AV8ProductPhoto));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductphoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV8ProductPhoto_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductprice_Internalname,StringUtil.LTrim( StringUtil.NToC( AV9ProductPrice, 11, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( AV9ProductPrice, "R$ ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProductprice_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavProductcountryname_Internalname,StringUtil.RTrim( AV10ProductCountryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavProductcountryname_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCategoryname_Internalname,StringUtil.RTrim( AV11CategoryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCategoryname_Jsonclick,(short)0,(string)"",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)23,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         AV6SellerPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV6SellerPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Sellerphoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV6SellerPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV6SellerPhoto)) ? AV16Sellerphoto_GXI : context.PathToRelativeUrl( AV6SellerPhoto));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavSellerphoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV6SellerPhoto_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes0N2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_23_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_23_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_23_idx+1);
         sGXsfl_23_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_23_idx), 4, 0), 4, "0");
         SubsflControlProps_232( ) ;
         /* End function sendrow_232 */
      }

      protected void init_web_controls( )
      {
         dynavProductcountryid.Name = "vPRODUCTCOUNTRYID";
         dynavProductcountryid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTable1_Internalname = "TABLE1";
         dynavProductcountryid_Internalname = "vPRODUCTCOUNTRYID";
         divTable2_Internalname = "TABLE2";
         edtavProductname_Internalname = "vPRODUCTNAME";
         edtavProductphoto_Internalname = "vPRODUCTPHOTO";
         edtavProductprice_Internalname = "vPRODUCTPRICE";
         edtavProductcountryname_Internalname = "vPRODUCTCOUNTRYNAME";
         edtavCategoryname_Internalname = "vCATEGORYNAME";
         edtavSellerphoto_Internalname = "vSELLERPHOTO";
         divTable3_Internalname = "TABLE3";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavCategoryname_Jsonclick = "";
         edtavProductcountryname_Jsonclick = "";
         edtavProductprice_Jsonclick = "";
         edtavProductname_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         subGrid1_Class = "";
         subGrid1_Backcolorstyle = 0;
         dynavProductcountryid_Jsonclick = "";
         dynavProductcountryid.Enabled = 1;
         dynavProductcountryid.BackColor = (int)(0xFFFFFF);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Produtos por País";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'A13ProductName',fld:'PRODUCTNAME',pic:''},{av:'A14ProductCountryID',fld:'PRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'A28ProductPhoto',fld:'PRODUCTPHOTO',pic:''},{av:'A40000ProductPhoto_GXI',fld:'PRODUCTPHOTO_GXI',pic:''},{av:'A27ProductPrice',fld:'PRODUCTPRICE',pic:'R$ ZZZZ9.99'},{av:'A39ProductCountryName',fld:'PRODUCTCOUNTRYNAME',pic:''},{av:'A7CategoryName',fld:'CATEGORYNAME',pic:''},{av:'A19SellerPhoto',fld:'SELLERPHOTO',pic:''},{av:'A40001SellerPhoto_GXI',fld:'SELLERPHOTO_GXI',pic:''},{av:'dynavProductcountryid'},{av:'AV5ProductCountryId',fld:'vPRODUCTCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavProductcountryid'},{av:'AV5ProductCountryId',fld:'vPRODUCTCOUNTRYID',pic:'ZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Validv_Sellerphoto',iparms:[{av:'dynavProductcountryid'},{av:'AV5ProductCountryId',fld:'vPRODUCTCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynavProductcountryid'},{av:'AV5ProductCountryId',fld:'vPRODUCTCOUNTRYID',pic:'ZZZ9'}]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A13ProductName = "";
         A28ProductPhoto = "";
         A40000ProductPhoto_GXI = "";
         A39ProductCountryName = "";
         A7CategoryName = "";
         A19SellerPhoto = "";
         A40001SellerPhoto_GXI = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV7ProductName = "";
         AV8ProductPhoto = "";
         AV10ProductCountryName = "";
         AV11CategoryName = "";
         AV6SellerPhoto = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV15Productphoto_GXI = "";
         AV16Sellerphoto_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H000N2_A12ProductId = new short[1] ;
         H000N2_A14ProductCountryID = new short[1] ;
         H000N2_A39ProductCountryName = new string[] {""} ;
         H000N3_A12ProductId = new short[1] ;
         H000N3_A6CategoryId = new short[1] ;
         H000N3_A10SellerId = new short[1] ;
         H000N3_A14ProductCountryID = new short[1] ;
         H000N3_A40000ProductPhoto_GXI = new string[] {""} ;
         H000N3_A40001SellerPhoto_GXI = new string[] {""} ;
         H000N3_A27ProductPrice = new decimal[1] ;
         H000N3_A39ProductCountryName = new string[] {""} ;
         H000N3_A7CategoryName = new string[] {""} ;
         H000N3_A13ProductName = new string[] {""} ;
         H000N3_A28ProductPhoto = new string[] {""} ;
         H000N3_A19SellerPhoto = new string[] {""} ;
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productspercountry__default(),
            new Object[][] {
                new Object[] {
               H000N2_A12ProductId, H000N2_A14ProductCountryID, H000N2_A39ProductCountryName
               }
               , new Object[] {
               H000N3_A12ProductId, H000N3_A6CategoryId, H000N3_A10SellerId, H000N3_A14ProductCountryID, H000N3_A40000ProductPhoto_GXI, H000N3_A40001SellerPhoto_GXI, H000N3_A27ProductPrice, H000N3_A39ProductCountryName, H000N3_A7CategoryName, H000N3_A13ProductName,
               H000N3_A28ProductPhoto, H000N3_A19SellerPhoto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A14ProductCountryID ;
      private short AV5ProductCountryId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A6CategoryId ;
      private short A10SellerId ;
      private short subGrid1_Backstyle ;
      private short GRID1_nEOF ;
      private int nRC_GXsfl_23 ;
      private int nGXsfl_23_idx=1 ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal A27ProductPrice ;
      private decimal AV9ProductPrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_23_idx="0001" ;
      private string A13ProductName ;
      private string A39ProductCountryName ;
      private string A7CategoryName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable2_Internalname ;
      private string dynavProductcountryid_Internalname ;
      private string TempTags ;
      private string dynavProductcountryid_Jsonclick ;
      private string divTable3_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string AV7ProductName ;
      private string AV10ProductCountryName ;
      private string AV11CategoryName ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavProductname_Internalname ;
      private string edtavProductphoto_Internalname ;
      private string edtavProductprice_Internalname ;
      private string edtavProductcountryname_Internalname ;
      private string edtavCategoryname_Internalname ;
      private string edtavSellerphoto_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string sGXsfl_23_fel_idx="0001" ;
      private string ROClassString ;
      private string edtavProductname_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtavProductprice_Jsonclick ;
      private string edtavProductcountryname_Jsonclick ;
      private string edtavCategoryname_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_23_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV8ProductPhoto_IsBlob ;
      private bool AV6SellerPhoto_IsBlob ;
      private string A40000ProductPhoto_GXI ;
      private string A40001SellerPhoto_GXI ;
      private string AV15Productphoto_GXI ;
      private string AV16Sellerphoto_GXI ;
      private string A28ProductPhoto ;
      private string A19SellerPhoto ;
      private string AV8ProductPhoto ;
      private string AV6SellerPhoto ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavProductcountryid ;
      private IDataStoreProvider pr_default ;
      private short[] H000N2_A12ProductId ;
      private short[] H000N2_A14ProductCountryID ;
      private string[] H000N2_A39ProductCountryName ;
      private short[] H000N3_A12ProductId ;
      private short[] H000N3_A6CategoryId ;
      private short[] H000N3_A10SellerId ;
      private short[] H000N3_A14ProductCountryID ;
      private string[] H000N3_A40000ProductPhoto_GXI ;
      private string[] H000N3_A40001SellerPhoto_GXI ;
      private decimal[] H000N3_A27ProductPrice ;
      private string[] H000N3_A39ProductCountryName ;
      private string[] H000N3_A7CategoryName ;
      private string[] H000N3_A13ProductName ;
      private string[] H000N3_A28ProductPhoto ;
      private string[] H000N3_A19SellerPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class productspercountry__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000N2;
          prmH000N2 = new Object[] {
          };
          Object[] prmH000N3;
          prmH000N3 = new Object[] {
          new ParDef("@AV5ProductCountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000N2", "SELECT T1.[ProductId], T1.[ProductCountryID] AS ProductCountryID, T2.[CountryName] AS ProductCountryName FROM ([Product] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[ProductCountryID]) ORDER BY T2.[CountryName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000N2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000N3", "SELECT T1.[ProductId], T1.[CategoryId], T1.[SellerId], T1.[ProductCountryID] AS ProductCountryID, T1.[ProductPhoto_GXI], T3.[SellerPhoto_GXI], T1.[ProductPrice], T4.[CountryName] AS ProductCountryName, T2.[CategoryName], T1.[ProductName], T1.[ProductPhoto], T3.[SellerPhoto] FROM ((([Product] T1 INNER JOIN [Category] T2 ON T2.[CategoryId] = T1.[CategoryId]) INNER JOIN [Seller] T3 ON T3.[SellerId] = T1.[SellerId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T1.[ProductCountryID]) WHERE T1.[ProductCountryID] = @AV5ProductCountryId ORDER BY T1.[ProductName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000N3,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(6));
                return;
       }
    }

 }

}
