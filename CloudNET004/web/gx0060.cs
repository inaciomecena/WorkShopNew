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
   public class gx0060 : GXDataArea
   {
      public gx0060( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public gx0060( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pProductId )
      {
         this.AV13pProductId = 0 ;
         executePrivate();
         aP0_pProductId=this.AV13pProductId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pProductId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pProductId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pProductId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."));
               sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
               subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
               AV6cProductId = (short)(NumberUtil.Val( GetPar( "cProductId"), "."));
               AV7cProductName = GetPar( "cProductName");
               AV8cProductDescription = GetPar( "cProductDescription");
               AV9cProductPrice = NumberUtil.Val( GetPar( "cProductPrice"), ".");
               AV10cProductCountryID = (short)(NumberUtil.Val( GetPar( "cProductCountryID"), "."));
               AV11cCategoryId = (short)(NumberUtil.Val( GetPar( "cCategoryId"), "."));
               AV12cSellerId = (short)(NumberUtil.Val( GetPar( "cSellerId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cProductId, AV7cProductName, AV8cProductDescription, AV9cProductPrice, AV10cProductCountryID, AV11cCategoryId, AV12cSellerId) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV13pProductId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pProductId", StringUtil.LTrimStr( (decimal)(AV13pProductId), 4, 0));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA0W2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0W2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202352622261356", false, true);
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0060.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pProductId,4,0))}, new string[] {"pProductId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cProductId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTNAME", StringUtil.RTrim( AV7cProductName));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTDESCRIPTION", StringUtil.RTrim( AV8cProductDescription));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTPRICE", StringUtil.LTrim( StringUtil.NToC( AV9cProductPrice, 8, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cProductCountryID), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCATEGORYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cCategoryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSELLERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cSellerId), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pProductId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divProductnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTDESCRIPTIONFILTERCONTAINER_Class", StringUtil.RTrim( divProductdescriptionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divProductpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTCOUNTRYIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductcountryidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CATEGORYIDFILTERCONTAINER_Class", StringUtil.RTrim( divCategoryidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SELLERIDFILTERCONTAINER_Class", StringUtil.RTrim( divSelleridfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
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
            WE0W2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0W2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx0060.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pProductId,4,0))}, new string[] {"pProductId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0060" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Product" ;
      }

      protected void WB0W0( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divProductidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductidfilter_Internalname, "Product Id", "", "", lblLblproductidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductid_Internalname, "Product Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cProductId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCproductid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cProductId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cProductId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductid_Visible, edtavCproductid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divProductnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductnamefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductnamefilter_Internalname, "Nome", "", "", lblLblproductnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductname_Internalname, "Nome", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductname_Internalname, StringUtil.RTrim( AV7cProductName), StringUtil.RTrim( context.localUtil.Format( AV7cProductName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductname_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductname_Visible, edtavCproductname_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divProductdescriptionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductdescriptionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductdescriptionfilter_Internalname, "Descri��o", "", "", lblLblproductdescriptionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductdescription_Internalname, "Descri��o", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductdescription_Internalname, StringUtil.RTrim( AV8cProductDescription), StringUtil.RTrim( context.localUtil.Format( AV8cProductDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductdescription_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductdescription_Visible, edtavCproductdescription_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divProductpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductpricefilter_Internalname, "Pre�o", "", "", lblLblproductpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductprice_Internalname, "Pre�o", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cProductPrice, 11, 2, ",", "")), StringUtil.LTrim( ((edtavCproductprice_Enabled!=0) ? context.localUtil.Format( AV9cProductPrice, "R$ ZZZZ9.99") : context.localUtil.Format( AV9cProductPrice, "R$ ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductprice_Visible, edtavCproductprice_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divProductcountryidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductcountryidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductcountryidfilter_Internalname, "Pais ID", "", "", lblLblproductcountryidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductcountryid_Internalname, "Pais ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductcountryid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cProductCountryID), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCproductcountryid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cProductCountryID), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cProductCountryID), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductcountryid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductcountryid_Visible, edtavCproductcountryid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divCategoryidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCategoryidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcategoryidfilter_Internalname, "Categoria Id", "", "", lblLblcategoryidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcategoryid_Internalname, "Categoria Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcategoryid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cCategoryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCcategoryid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cCategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cCategoryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcategoryid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcategoryid_Visible, edtavCcategoryid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divSelleridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSelleridfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblselleridfilter_Internalname, "Vendedor Id", "", "", lblLblselleridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170w1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsellerid_Internalname, "Vendedor Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsellerid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cSellerId), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCsellerid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cSellerId), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cSellerId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsellerid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsellerid_Visible, edtavCsellerid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180w1_client"+"'", TempTags, "", 2, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nome") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descri��o") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Pre�o") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Foto") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Categoria Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Vendedor Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A13ProductName));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtProductName_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A26ProductDescription));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( A28ProductPhoto));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14ProductCountryID), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SellerId), 4, 0, ".", "")));
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
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
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
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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

      protected void START0W2( )
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
            Form.Meta.addItem("description", "Selection List Product", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0W0( ) ;
      }

      protected void WS0W2( )
      {
         START0W2( ) ;
         EVT0W2( ) ;
      }

      protected void EVT0W2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A12ProductId = (short)(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", "."));
                              A13ProductName = cgiGet( edtProductName_Internalname);
                              A26ProductDescription = cgiGet( edtProductDescription_Internalname);
                              A27ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".");
                              A28ProductPhoto = cgiGet( edtProductPhoto_Internalname);
                              AssignProp("", false, edtProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
                              A14ProductCountryID = (short)(context.localUtil.CToN( cgiGet( edtProductCountryID_Internalname), ",", "."));
                              A6CategoryId = (short)(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", "."));
                              A10SellerId = (short)(context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200W2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cproductid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ",", ".") != Convert.ToDecimal( AV6cProductId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTNAME"), AV7cProductName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductdescription Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTDESCRIPTION"), AV8cProductDescription) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTPRICE"), ",", ".") != AV9cProductPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductcountryid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTCOUNTRYID"), ",", ".") != Convert.ToDecimal( AV10cProductCountryID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccategoryid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORYID"), ",", ".") != Convert.ToDecimal( AV11cCategoryId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csellerid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSELLERID"), ",", ".") != Convert.ToDecimal( AV12cSellerId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210W2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE0W2( )
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

      protected void PA0W2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cProductId ,
                                        string AV7cProductName ,
                                        string AV8cProductDescription ,
                                        decimal AV9cProductPrice ,
                                        short AV10cProductCountryID ,
                                        short AV11cCategoryId ,
                                        short AV12cSellerId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0W2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0W2( ) ;
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

      protected void RF0W2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cProductName ,
                                                 AV8cProductDescription ,
                                                 AV9cProductPrice ,
                                                 AV10cProductCountryID ,
                                                 AV11cCategoryId ,
                                                 AV12cSellerId ,
                                                 A13ProductName ,
                                                 A26ProductDescription ,
                                                 A27ProductPrice ,
                                                 A14ProductCountryID ,
                                                 A6CategoryId ,
                                                 A10SellerId ,
                                                 AV6cProductId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cProductName = StringUtil.PadR( StringUtil.RTrim( AV7cProductName), 20, "%");
            lV8cProductDescription = StringUtil.PadR( StringUtil.RTrim( AV8cProductDescription), 50, "%");
            /* Using cursor H000W2 */
            pr_default.execute(0, new Object[] {AV6cProductId, lV7cProductName, lV8cProductDescription, AV9cProductPrice, AV10cProductCountryID, AV11cCategoryId, AV12cSellerId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A10SellerId = H000W2_A10SellerId[0];
               A6CategoryId = H000W2_A6CategoryId[0];
               A14ProductCountryID = H000W2_A14ProductCountryID[0];
               A40000ProductPhoto_GXI = H000W2_A40000ProductPhoto_GXI[0];
               AssignProp("", false, edtProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
               A27ProductPrice = H000W2_A27ProductPrice[0];
               A26ProductDescription = H000W2_A26ProductDescription[0];
               A13ProductName = H000W2_A13ProductName[0];
               A12ProductId = H000W2_A12ProductId[0];
               A28ProductPhoto = H000W2_A28ProductPhoto[0];
               AssignProp("", false, edtProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
               /* Execute user event: Load */
               E200W2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0W0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0W2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cProductName ,
                                              AV8cProductDescription ,
                                              AV9cProductPrice ,
                                              AV10cProductCountryID ,
                                              AV11cCategoryId ,
                                              AV12cSellerId ,
                                              A13ProductName ,
                                              A26ProductDescription ,
                                              A27ProductPrice ,
                                              A14ProductCountryID ,
                                              A6CategoryId ,
                                              A10SellerId ,
                                              AV6cProductId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cProductName = StringUtil.PadR( StringUtil.RTrim( AV7cProductName), 20, "%");
         lV8cProductDescription = StringUtil.PadR( StringUtil.RTrim( AV8cProductDescription), 50, "%");
         /* Using cursor H000W3 */
         pr_default.execute(1, new Object[] {AV6cProductId, lV7cProductName, lV8cProductDescription, AV9cProductPrice, AV10cProductCountryID, AV11cCategoryId, AV12cSellerId});
         GRID1_nRecordCount = H000W3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductId, AV7cProductName, AV8cProductDescription, AV9cProductPrice, AV10cProductCountryID, AV11cCategoryId, AV12cSellerId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductId, AV7cProductName, AV8cProductDescription, AV9cProductPrice, AV10cProductCountryID, AV11cCategoryId, AV12cSellerId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductId, AV7cProductName, AV8cProductDescription, AV9cProductPrice, AV10cProductCountryID, AV11cCategoryId, AV12cSellerId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductId, AV7cProductName, AV8cProductDescription, AV9cProductPrice, AV10cProductCountryID, AV11cCategoryId, AV12cSellerId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProductId, AV7cProductName, AV8cProductDescription, AV9cProductPrice, AV10cProductCountryID, AV11cCategoryId, AV12cSellerId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0W0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190W2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTID");
               GX_FocusControl = edtavCproductid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cProductId = 0;
               AssignAttri("", false, "AV6cProductId", StringUtil.LTrimStr( (decimal)(AV6cProductId), 4, 0));
            }
            else
            {
               AV6cProductId = (short)(context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cProductId", StringUtil.LTrimStr( (decimal)(AV6cProductId), 4, 0));
            }
            AV7cProductName = cgiGet( edtavCproductname_Internalname);
            AssignAttri("", false, "AV7cProductName", AV7cProductName);
            AV8cProductDescription = cgiGet( edtavCproductdescription_Internalname);
            AssignAttri("", false, "AV8cProductDescription", AV8cProductDescription);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductprice_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductprice_Internalname), ",", ".") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTPRICE");
               GX_FocusControl = edtavCproductprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cProductPrice = 0;
               AssignAttri("", false, "AV9cProductPrice", StringUtil.LTrimStr( AV9cProductPrice, 8, 2));
            }
            else
            {
               AV9cProductPrice = context.localUtil.CToN( cgiGet( edtavCproductprice_Internalname), ",", ".");
               AssignAttri("", false, "AV9cProductPrice", StringUtil.LTrimStr( AV9cProductPrice, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductcountryid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductcountryid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTCOUNTRYID");
               GX_FocusControl = edtavCproductcountryid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cProductCountryID = 0;
               AssignAttri("", false, "AV10cProductCountryID", StringUtil.LTrimStr( (decimal)(AV10cProductCountryID), 4, 0));
            }
            else
            {
               AV10cProductCountryID = (short)(context.localUtil.CToN( cgiGet( edtavCproductcountryid_Internalname), ",", "."));
               AssignAttri("", false, "AV10cProductCountryID", StringUtil.LTrimStr( (decimal)(AV10cProductCountryID), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcategoryid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcategoryid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCATEGORYID");
               GX_FocusControl = edtavCcategoryid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cCategoryId = 0;
               AssignAttri("", false, "AV11cCategoryId", StringUtil.LTrimStr( (decimal)(AV11cCategoryId), 4, 0));
            }
            else
            {
               AV11cCategoryId = (short)(context.localUtil.CToN( cgiGet( edtavCcategoryid_Internalname), ",", "."));
               AssignAttri("", false, "AV11cCategoryId", StringUtil.LTrimStr( (decimal)(AV11cCategoryId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsellerid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsellerid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSELLERID");
               GX_FocusControl = edtavCsellerid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cSellerId = 0;
               AssignAttri("", false, "AV12cSellerId", StringUtil.LTrimStr( (decimal)(AV12cSellerId), 4, 0));
            }
            else
            {
               AV12cSellerId = (short)(context.localUtil.CToN( cgiGet( edtavCsellerid_Internalname), ",", "."));
               AssignAttri("", false, "AV12cSellerId", StringUtil.LTrimStr( (decimal)(AV12cSellerId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ",", ".") != Convert.ToDecimal( AV6cProductId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTNAME"), AV7cProductName) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUCTDESCRIPTION"), AV8cProductDescription) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTPRICE"), ",", ".") != AV9cProductPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTCOUNTRYID"), ",", ".") != Convert.ToDecimal( AV10cProductCountryID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORYID"), ",", ".") != Convert.ToDecimal( AV11cCategoryId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSELLERID"), ",", ".") != Convert.ToDecimal( AV12cSellerId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E190W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190W2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Sele��o %1", "Product", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200W2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E210W2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210W2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pProductId = A12ProductId;
         AssignAttri("", false, "AV13pProductId", StringUtil.LTrimStr( (decimal)(AV13pProductId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pProductId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pProductId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pProductId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pProductId", StringUtil.LTrimStr( (decimal)(AV13pProductId), 4, 0));
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
         PA0W2( ) ;
         WS0W2( ) ;
         WE0W2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202352622261682", true, true);
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
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gx0060.js", "?202352622261682", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_84_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_84_idx;
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION_"+sGXsfl_84_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_84_idx;
         edtProductPhoto_Internalname = "PRODUCTPHOTO_"+sGXsfl_84_idx;
         edtProductCountryID_Internalname = "PRODUCTCOUNTRYID_"+sGXsfl_84_idx;
         edtCategoryId_Internalname = "CATEGORYID_"+sGXsfl_84_idx;
         edtSellerId_Internalname = "SELLERID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_84_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_84_fel_idx;
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION_"+sGXsfl_84_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_84_fel_idx;
         edtProductPhoto_Internalname = "PRODUCTPHOTO_"+sGXsfl_84_fel_idx;
         edtProductCountryID_Internalname = "PRODUCTCOUNTRYID_"+sGXsfl_84_fel_idx;
         edtCategoryId_Internalname = "CATEGORYID_"+sGXsfl_84_fel_idx;
         edtSellerId_Internalname = "SELLERID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0W0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtProductName_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtProductName_Internalname, "Link", edtProductName_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,StringUtil.RTrim( A13ProductName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProductName_Link,(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductDescription_Internalname,StringUtil.RTrim( A26ProductDescription),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 11, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A27ProductPrice, "R$ ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A28ProductPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.PathToRelativeUrl( A28ProductPhoto));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A28ProductPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCountryID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14ProductCountryID), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14ProductCountryID), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCountryID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoryId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoryId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSellerId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SellerId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSellerId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0W2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblproductidfilter_Internalname = "LBLPRODUCTIDFILTER";
         edtavCproductid_Internalname = "vCPRODUCTID";
         divProductidfiltercontainer_Internalname = "PRODUCTIDFILTERCONTAINER";
         lblLblproductnamefilter_Internalname = "LBLPRODUCTNAMEFILTER";
         edtavCproductname_Internalname = "vCPRODUCTNAME";
         divProductnamefiltercontainer_Internalname = "PRODUCTNAMEFILTERCONTAINER";
         lblLblproductdescriptionfilter_Internalname = "LBLPRODUCTDESCRIPTIONFILTER";
         edtavCproductdescription_Internalname = "vCPRODUCTDESCRIPTION";
         divProductdescriptionfiltercontainer_Internalname = "PRODUCTDESCRIPTIONFILTERCONTAINER";
         lblLblproductpricefilter_Internalname = "LBLPRODUCTPRICEFILTER";
         edtavCproductprice_Internalname = "vCPRODUCTPRICE";
         divProductpricefiltercontainer_Internalname = "PRODUCTPRICEFILTERCONTAINER";
         lblLblproductcountryidfilter_Internalname = "LBLPRODUCTCOUNTRYIDFILTER";
         edtavCproductcountryid_Internalname = "vCPRODUCTCOUNTRYID";
         divProductcountryidfiltercontainer_Internalname = "PRODUCTCOUNTRYIDFILTERCONTAINER";
         lblLblcategoryidfilter_Internalname = "LBLCATEGORYIDFILTER";
         edtavCcategoryid_Internalname = "vCCATEGORYID";
         divCategoryidfiltercontainer_Internalname = "CATEGORYIDFILTERCONTAINER";
         lblLblselleridfilter_Internalname = "LBLSELLERIDFILTER";
         edtavCsellerid_Internalname = "vCSELLERID";
         divSelleridfiltercontainer_Internalname = "SELLERIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtProductPhoto_Internalname = "PRODUCTPHOTO";
         edtProductCountryID_Internalname = "PRODUCTCOUNTRYID";
         edtCategoryId_Internalname = "CATEGORYID";
         edtSellerId_Internalname = "SELLERID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
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
         edtSellerId_Jsonclick = "";
         edtCategoryId_Jsonclick = "";
         edtProductCountryID_Jsonclick = "";
         edtProductPrice_Jsonclick = "";
         edtProductDescription_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtProductName_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCsellerid_Jsonclick = "";
         edtavCsellerid_Enabled = 1;
         edtavCsellerid_Visible = 1;
         edtavCcategoryid_Jsonclick = "";
         edtavCcategoryid_Enabled = 1;
         edtavCcategoryid_Visible = 1;
         edtavCproductcountryid_Jsonclick = "";
         edtavCproductcountryid_Enabled = 1;
         edtavCproductcountryid_Visible = 1;
         edtavCproductprice_Jsonclick = "";
         edtavCproductprice_Enabled = 1;
         edtavCproductprice_Visible = 1;
         edtavCproductdescription_Jsonclick = "";
         edtavCproductdescription_Enabled = 1;
         edtavCproductdescription_Visible = 1;
         edtavCproductname_Jsonclick = "";
         edtavCproductname_Enabled = 1;
         edtavCproductname_Visible = 1;
         edtavCproductid_Jsonclick = "";
         edtavCproductid_Enabled = 1;
         edtavCproductid_Visible = 1;
         divSelleridfiltercontainer_Class = "AdvancedContainerItem";
         divCategoryidfiltercontainer_Class = "AdvancedContainerItem";
         divProductcountryidfiltercontainer_Class = "AdvancedContainerItem";
         divProductpricefiltercontainer_Class = "AdvancedContainerItem";
         divProductdescriptionfiltercontainer_Class = "AdvancedContainerItem";
         divProductnamefiltercontainer_Class = "AdvancedContainerItem";
         divProductidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Product";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProductId',fld:'vCPRODUCTID',pic:'ZZZ9'},{av:'AV7cProductName',fld:'vCPRODUCTNAME',pic:''},{av:'AV8cProductDescription',fld:'vCPRODUCTDESCRIPTION',pic:''},{av:'AV9cProductPrice',fld:'vCPRODUCTPRICE',pic:'R$ ZZZZ9.99'},{av:'AV10cProductCountryID',fld:'vCPRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'AV11cCategoryId',fld:'vCCATEGORYID',pic:'ZZZ9'},{av:'AV12cSellerId',fld:'vCSELLERID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180W1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK","{handler:'E110W1',iparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK",",oparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproductid_Visible',ctrl:'vCPRODUCTID',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTNAMEFILTER.CLICK","{handler:'E120W1',iparms:[{av:'divProductnamefiltercontainer_Class',ctrl:'PRODUCTNAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTNAMEFILTER.CLICK",",oparms:[{av:'divProductnamefiltercontainer_Class',ctrl:'PRODUCTNAMEFILTERCONTAINER',prop:'Class'},{av:'edtavCproductname_Visible',ctrl:'vCPRODUCTNAME',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTDESCRIPTIONFILTER.CLICK","{handler:'E130W1',iparms:[{av:'divProductdescriptionfiltercontainer_Class',ctrl:'PRODUCTDESCRIPTIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTDESCRIPTIONFILTER.CLICK",",oparms:[{av:'divProductdescriptionfiltercontainer_Class',ctrl:'PRODUCTDESCRIPTIONFILTERCONTAINER',prop:'Class'},{av:'edtavCproductdescription_Visible',ctrl:'vCPRODUCTDESCRIPTION',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTPRICEFILTER.CLICK","{handler:'E140W1',iparms:[{av:'divProductpricefiltercontainer_Class',ctrl:'PRODUCTPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTPRICEFILTER.CLICK",",oparms:[{av:'divProductpricefiltercontainer_Class',ctrl:'PRODUCTPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCproductprice_Visible',ctrl:'vCPRODUCTPRICE',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTCOUNTRYIDFILTER.CLICK","{handler:'E150W1',iparms:[{av:'divProductcountryidfiltercontainer_Class',ctrl:'PRODUCTCOUNTRYIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTCOUNTRYIDFILTER.CLICK",",oparms:[{av:'divProductcountryidfiltercontainer_Class',ctrl:'PRODUCTCOUNTRYIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproductcountryid_Visible',ctrl:'vCPRODUCTCOUNTRYID',prop:'Visible'}]}");
         setEventMetadata("LBLCATEGORYIDFILTER.CLICK","{handler:'E160W1',iparms:[{av:'divCategoryidfiltercontainer_Class',ctrl:'CATEGORYIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCATEGORYIDFILTER.CLICK",",oparms:[{av:'divCategoryidfiltercontainer_Class',ctrl:'CATEGORYIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcategoryid_Visible',ctrl:'vCCATEGORYID',prop:'Visible'}]}");
         setEventMetadata("LBLSELLERIDFILTER.CLICK","{handler:'E170W1',iparms:[{av:'divSelleridfiltercontainer_Class',ctrl:'SELLERIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSELLERIDFILTER.CLICK",",oparms:[{av:'divSelleridfiltercontainer_Class',ctrl:'SELLERIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsellerid_Visible',ctrl:'vCSELLERID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210W2',iparms:[{av:'A12ProductId',fld:'PRODUCTID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pProductId',fld:'vPPRODUCTID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProductId',fld:'vCPRODUCTID',pic:'ZZZ9'},{av:'AV7cProductName',fld:'vCPRODUCTNAME',pic:''},{av:'AV8cProductDescription',fld:'vCPRODUCTDESCRIPTION',pic:''},{av:'AV9cProductPrice',fld:'vCPRODUCTPRICE',pic:'R$ ZZZZ9.99'},{av:'AV10cProductCountryID',fld:'vCPRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'AV11cCategoryId',fld:'vCCATEGORYID',pic:'ZZZ9'},{av:'AV12cSellerId',fld:'vCSELLERID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProductId',fld:'vCPRODUCTID',pic:'ZZZ9'},{av:'AV7cProductName',fld:'vCPRODUCTNAME',pic:''},{av:'AV8cProductDescription',fld:'vCPRODUCTDESCRIPTION',pic:''},{av:'AV9cProductPrice',fld:'vCPRODUCTPRICE',pic:'R$ ZZZZ9.99'},{av:'AV10cProductCountryID',fld:'vCPRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'AV11cCategoryId',fld:'vCCATEGORYID',pic:'ZZZ9'},{av:'AV12cSellerId',fld:'vCSELLERID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProductId',fld:'vCPRODUCTID',pic:'ZZZ9'},{av:'AV7cProductName',fld:'vCPRODUCTNAME',pic:''},{av:'AV8cProductDescription',fld:'vCPRODUCTDESCRIPTION',pic:''},{av:'AV9cProductPrice',fld:'vCPRODUCTPRICE',pic:'R$ ZZZZ9.99'},{av:'AV10cProductCountryID',fld:'vCPRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'AV11cCategoryId',fld:'vCCATEGORYID',pic:'ZZZ9'},{av:'AV12cSellerId',fld:'vCSELLERID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProductId',fld:'vCPRODUCTID',pic:'ZZZ9'},{av:'AV7cProductName',fld:'vCPRODUCTNAME',pic:''},{av:'AV8cProductDescription',fld:'vCPRODUCTDESCRIPTION',pic:''},{av:'AV9cProductPrice',fld:'vCPRODUCTPRICE',pic:'R$ ZZZZ9.99'},{av:'AV10cProductCountryID',fld:'vCPRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'AV11cCategoryId',fld:'vCCATEGORYID',pic:'ZZZ9'},{av:'AV12cSellerId',fld:'vCSELLERID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Sellerid',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV7cProductName = "";
         AV8cProductDescription = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblproductidfilter_Jsonclick = "";
         TempTags = "";
         lblLblproductnamefilter_Jsonclick = "";
         lblLblproductdescriptionfilter_Jsonclick = "";
         lblLblproductpricefilter_Jsonclick = "";
         lblLblproductcountryidfilter_Jsonclick = "";
         lblLblcategoryidfilter_Jsonclick = "";
         lblLblselleridfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A13ProductName = "";
         A26ProductDescription = "";
         A28ProductPhoto = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         A40000ProductPhoto_GXI = "";
         scmdbuf = "";
         lV7cProductName = "";
         lV8cProductDescription = "";
         H000W2_A10SellerId = new short[1] ;
         H000W2_A6CategoryId = new short[1] ;
         H000W2_A14ProductCountryID = new short[1] ;
         H000W2_A40000ProductPhoto_GXI = new string[] {""} ;
         H000W2_A27ProductPrice = new decimal[1] ;
         H000W2_A26ProductDescription = new string[] {""} ;
         H000W2_A13ProductName = new string[] {""} ;
         H000W2_A12ProductId = new short[1] ;
         H000W2_A28ProductPhoto = new string[] {""} ;
         H000W3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0060__default(),
            new Object[][] {
                new Object[] {
               H000W2_A10SellerId, H000W2_A6CategoryId, H000W2_A14ProductCountryID, H000W2_A40000ProductPhoto_GXI, H000W2_A27ProductPrice, H000W2_A26ProductDescription, H000W2_A13ProductName, H000W2_A12ProductId, H000W2_A28ProductPhoto
               }
               , new Object[] {
               H000W3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pProductId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cProductId ;
      private short AV10cProductCountryID ;
      private short AV11cCategoryId ;
      private short AV12cSellerId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A12ProductId ;
      private short A14ProductCountryID ;
      private short A6CategoryId ;
      private short A10SellerId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCproductid_Enabled ;
      private int edtavCproductid_Visible ;
      private int edtavCproductname_Visible ;
      private int edtavCproductname_Enabled ;
      private int edtavCproductdescription_Visible ;
      private int edtavCproductdescription_Enabled ;
      private int edtavCproductprice_Enabled ;
      private int edtavCproductprice_Visible ;
      private int edtavCproductcountryid_Enabled ;
      private int edtavCproductcountryid_Visible ;
      private int edtavCcategoryid_Enabled ;
      private int edtavCcategoryid_Visible ;
      private int edtavCsellerid_Enabled ;
      private int edtavCsellerid_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV9cProductPrice ;
      private decimal A27ProductPrice ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divProductidfiltercontainer_Class ;
      private string divProductnamefiltercontainer_Class ;
      private string divProductdescriptionfiltercontainer_Class ;
      private string divProductpricefiltercontainer_Class ;
      private string divProductcountryidfiltercontainer_Class ;
      private string divCategoryidfiltercontainer_Class ;
      private string divSelleridfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string AV7cProductName ;
      private string AV8cProductDescription ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divProductidfiltercontainer_Internalname ;
      private string lblLblproductidfilter_Internalname ;
      private string lblLblproductidfilter_Jsonclick ;
      private string edtavCproductid_Internalname ;
      private string TempTags ;
      private string edtavCproductid_Jsonclick ;
      private string divProductnamefiltercontainer_Internalname ;
      private string lblLblproductnamefilter_Internalname ;
      private string lblLblproductnamefilter_Jsonclick ;
      private string edtavCproductname_Internalname ;
      private string edtavCproductname_Jsonclick ;
      private string divProductdescriptionfiltercontainer_Internalname ;
      private string lblLblproductdescriptionfilter_Internalname ;
      private string lblLblproductdescriptionfilter_Jsonclick ;
      private string edtavCproductdescription_Internalname ;
      private string edtavCproductdescription_Jsonclick ;
      private string divProductpricefiltercontainer_Internalname ;
      private string lblLblproductpricefilter_Internalname ;
      private string lblLblproductpricefilter_Jsonclick ;
      private string edtavCproductprice_Internalname ;
      private string edtavCproductprice_Jsonclick ;
      private string divProductcountryidfiltercontainer_Internalname ;
      private string lblLblproductcountryidfilter_Internalname ;
      private string lblLblproductcountryidfilter_Jsonclick ;
      private string edtavCproductcountryid_Internalname ;
      private string edtavCproductcountryid_Jsonclick ;
      private string divCategoryidfiltercontainer_Internalname ;
      private string lblLblcategoryidfilter_Internalname ;
      private string lblLblcategoryidfilter_Jsonclick ;
      private string edtavCcategoryid_Internalname ;
      private string edtavCcategoryid_Jsonclick ;
      private string divSelleridfiltercontainer_Internalname ;
      private string lblLblselleridfilter_Internalname ;
      private string lblLblselleridfilter_Jsonclick ;
      private string edtavCsellerid_Internalname ;
      private string edtavCsellerid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string A13ProductName ;
      private string edtProductName_Link ;
      private string A26ProductDescription ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductDescription_Internalname ;
      private string edtProductPrice_Internalname ;
      private string edtProductPhoto_Internalname ;
      private string edtProductCountryID_Internalname ;
      private string edtCategoryId_Internalname ;
      private string edtSellerId_Internalname ;
      private string scmdbuf ;
      private string lV7cProductName ;
      private string lV8cProductDescription ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductDescription_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string edtProductCountryID_Jsonclick ;
      private string edtCategoryId_Jsonclick ;
      private string edtSellerId_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A28ProductPhoto_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string A40000ProductPhoto_GXI ;
      private string AV5LinkSelection ;
      private string A28ProductPhoto ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000W2_A10SellerId ;
      private short[] H000W2_A6CategoryId ;
      private short[] H000W2_A14ProductCountryID ;
      private string[] H000W2_A40000ProductPhoto_GXI ;
      private decimal[] H000W2_A27ProductPrice ;
      private string[] H000W2_A26ProductDescription ;
      private string[] H000W2_A13ProductName ;
      private short[] H000W2_A12ProductId ;
      private string[] H000W2_A28ProductPhoto ;
      private long[] H000W3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pProductId ;
      private GXWebForm Form ;
   }

   public class gx0060__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000W2( IGxContext context ,
                                             string AV7cProductName ,
                                             string AV8cProductDescription ,
                                             decimal AV9cProductPrice ,
                                             short AV10cProductCountryID ,
                                             short AV11cCategoryId ,
                                             short AV12cSellerId ,
                                             string A13ProductName ,
                                             string A26ProductDescription ,
                                             decimal A27ProductPrice ,
                                             short A14ProductCountryID ,
                                             short A6CategoryId ,
                                             short A10SellerId ,
                                             short AV6cProductId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [SellerId], [CategoryId], [ProductCountryID], [ProductPhoto_GXI], [ProductPrice], [ProductDescription], [ProductName], [ProductId], [ProductPhoto]";
         sFromString = " FROM [Product]";
         sOrderString = "";
         AddWhere(sWhereString, "([ProductId] >= @AV6cProductId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cProductName)) )
         {
            AddWhere(sWhereString, "([ProductName] like @lV7cProductName)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProductDescription)) )
         {
            AddWhere(sWhereString, "([ProductDescription] like @lV8cProductDescription)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cProductPrice) )
         {
            AddWhere(sWhereString, "([ProductPrice] >= @AV9cProductPrice)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cProductCountryID) )
         {
            AddWhere(sWhereString, "([ProductCountryID] >= @AV10cProductCountryID)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cCategoryId) )
         {
            AddWhere(sWhereString, "([CategoryId] >= @AV11cCategoryId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cSellerId) )
         {
            AddWhere(sWhereString, "([SellerId] >= @AV12cSellerId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ProductId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000W3( IGxContext context ,
                                             string AV7cProductName ,
                                             string AV8cProductDescription ,
                                             decimal AV9cProductPrice ,
                                             short AV10cProductCountryID ,
                                             short AV11cCategoryId ,
                                             short AV12cSellerId ,
                                             string A13ProductName ,
                                             string A26ProductDescription ,
                                             decimal A27ProductPrice ,
                                             short A14ProductCountryID ,
                                             short A6CategoryId ,
                                             short A10SellerId ,
                                             short AV6cProductId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Product]";
         AddWhere(sWhereString, "([ProductId] >= @AV6cProductId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cProductName)) )
         {
            AddWhere(sWhereString, "([ProductName] like @lV7cProductName)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProductDescription)) )
         {
            AddWhere(sWhereString, "([ProductDescription] like @lV8cProductDescription)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cProductPrice) )
         {
            AddWhere(sWhereString, "([ProductPrice] >= @AV9cProductPrice)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cProductCountryID) )
         {
            AddWhere(sWhereString, "([ProductCountryID] >= @AV10cProductCountryID)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cCategoryId) )
         {
            AddWhere(sWhereString, "([CategoryId] >= @AV11cCategoryId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cSellerId) )
         {
            AddWhere(sWhereString, "([SellerId] >= @AV12cSellerId)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H000W3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH000W2;
          prmH000W2 = new Object[] {
          new ParDef("@AV6cProductId",GXType.Int16,4,0) ,
          new ParDef("@lV7cProductName",GXType.NChar,20,0) ,
          new ParDef("@lV8cProductDescription",GXType.NChar,50,0) ,
          new ParDef("@AV9cProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@AV10cProductCountryID",GXType.Int16,4,0) ,
          new ParDef("@AV11cCategoryId",GXType.Int16,4,0) ,
          new ParDef("@AV12cSellerId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000W3;
          prmH000W3 = new Object[] {
          new ParDef("@AV6cProductId",GXType.Int16,4,0) ,
          new ParDef("@lV7cProductName",GXType.NChar,20,0) ,
          new ParDef("@lV8cProductDescription",GXType.NChar,50,0) ,
          new ParDef("@AV9cProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@AV10cProductCountryID",GXType.Int16,4,0) ,
          new ParDef("@AV11cCategoryId",GXType.Int16,4,0) ,
          new ParDef("@AV12cSellerId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000W3,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
