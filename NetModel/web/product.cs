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
   public class product : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A14ProductCountryID = (short)(NumberUtil.Val( GetPar( "ProductCountryID"), "."));
            AssignAttri("", false, "A14ProductCountryID", StringUtil.LTrimStr( (decimal)(A14ProductCountryID), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A14ProductCountryID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A6CategoryId = (short)(NumberUtil.Val( GetPar( "CategoryId"), "."));
            AssignAttri("", false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A6CategoryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A10SellerId = (short)(NumberUtil.Val( GetPar( "SellerId"), "."));
            AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A10SellerId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A8CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A8CountryId) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Product", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public product( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public product( IGxContext context )
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
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Product", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 4, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID"+"'), id:'"+"PRODUCTID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ProductId), 4, 0, ",", "")), StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9") : context.localUtil.Format( (decimal)(A12ProductId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, StringUtil.RTrim( A13ProductName), StringUtil.RTrim( context.localUtil.Format( A13ProductName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductDescription_Internalname, StringUtil.RTrim( A26ProductDescription), StringUtil.RTrim( context.localUtil.Format( A26ProductDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductDescription_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPrice_Internalname, "Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 10, 2, ",", "")), StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A27ProductPrice, "$ ZZZZ9.99") : context.localUtil.Format( A27ProductPrice, "$ ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPrice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgProductPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A28ProductPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.PathToRelativeUrl( A28ProductPhoto));
         GxWebStd.gx_bitmap( context, imgProductPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A28ProductPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         AssignProp("", false, imgProductPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.PathToRelativeUrl( A28ProductPhoto)), true);
         AssignProp("", false, imgProductPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A28ProductPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCountryID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCountryID_Internalname, "Country ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductCountryID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14ProductCountryID), 4, 0, ",", "")), StringUtil.LTrim( ((edtProductCountryID_Enabled!=0) ? context.localUtil.Format( (decimal)(A14ProductCountryID), "ZZZ9") : context.localUtil.Format( (decimal)(A14ProductCountryID), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCountryID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCountryID_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_14_Internalname, sImgUrl, imgprompt_14_Link, "", "", context.GetTheme( ), imgprompt_14_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductCountryName_Internalname, StringUtil.RTrim( A39ProductCountryName), StringUtil.RTrim( context.localUtil.Format( A39ProductCountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryId_Internalname, "Category Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCategoryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9") : context.localUtil.Format( (decimal)(A6CategoryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_6_Internalname, sImgUrl, imgprompt_6_Link, "", "", context.GetTheme( ), imgprompt_6_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoryName_Internalname, "Category Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCategoryName_Internalname, StringUtil.RTrim( A7CategoryName), StringUtil.RTrim( context.localUtil.Format( A7CategoryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSellerId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSellerId_Internalname, "Seller Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSellerId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SellerId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSellerId_Enabled!=0) ? context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9") : context.localUtil.Format( (decimal)(A10SellerId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSellerId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_10_Internalname, sImgUrl, imgprompt_10_Link, "", "", context.GetTheme( ), imgprompt_10_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSellerName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSellerName_Internalname, "Seller Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSellerName_Internalname, StringUtil.RTrim( A18SellerName), StringUtil.RTrim( context.localUtil.Format( A18SellerName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSellerName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSellerName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgSellerPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Seller Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A19SellerPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001SellerPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.PathToRelativeUrl( A19SellerPhoto));
         GxWebStd.gx_bitmap( context, imgSellerPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgSellerPhoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 0, A19SellerPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         AssignProp("", false, imgSellerPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.PathToRelativeUrl( A19SellerPhoto)), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A19SellerPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ",", "")), StringUtil.LTrim( ((edtCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A8CountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A9CountryName), StringUtil.RTrim( context.localUtil.Format( A9CountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z12ProductId = (short)(context.localUtil.CToN( cgiGet( "Z12ProductId"), ",", "."));
            Z13ProductName = cgiGet( "Z13ProductName");
            Z26ProductDescription = cgiGet( "Z26ProductDescription");
            Z27ProductPrice = context.localUtil.CToN( cgiGet( "Z27ProductPrice"), ",", ".");
            Z6CategoryId = (short)(context.localUtil.CToN( cgiGet( "Z6CategoryId"), ",", "."));
            Z10SellerId = (short)(context.localUtil.CToN( cgiGet( "Z10SellerId"), ",", "."));
            Z14ProductCountryID = (short)(context.localUtil.CToN( cgiGet( "Z14ProductCountryID"), ",", "."));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            A40000ProductPhoto_GXI = cgiGet( "PRODUCTPHOTO_GXI");
            A40001SellerPhoto_GXI = cgiGet( "SELLERPHOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTID");
               AnyError = 1;
               GX_FocusControl = edtProductId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A12ProductId = 0;
               AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
            }
            else
            {
               A12ProductId = (short)(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ",", "."));
               AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
            }
            A13ProductName = cgiGet( edtProductName_Internalname);
            AssignAttri("", false, "A13ProductName", A13ProductName);
            A26ProductDescription = cgiGet( edtProductDescription_Internalname);
            AssignAttri("", false, "A26ProductDescription", A26ProductDescription);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTPRICE");
               AnyError = 1;
               GX_FocusControl = edtProductPrice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A27ProductPrice = 0;
               AssignAttri("", false, "A27ProductPrice", StringUtil.LTrimStr( A27ProductPrice, 8, 2));
            }
            else
            {
               A27ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ",", ".");
               AssignAttri("", false, "A27ProductPrice", StringUtil.LTrimStr( A27ProductPrice, 8, 2));
            }
            A28ProductPhoto = cgiGet( imgProductPhoto_Internalname);
            AssignAttri("", false, "A28ProductPhoto", A28ProductPhoto);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProductCountryID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductCountryID_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTCOUNTRYID");
               AnyError = 1;
               GX_FocusControl = edtProductCountryID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A14ProductCountryID = 0;
               AssignAttri("", false, "A14ProductCountryID", StringUtil.LTrimStr( (decimal)(A14ProductCountryID), 4, 0));
            }
            else
            {
               A14ProductCountryID = (short)(context.localUtil.CToN( cgiGet( edtProductCountryID_Internalname), ",", "."));
               AssignAttri("", false, "A14ProductCountryID", StringUtil.LTrimStr( (decimal)(A14ProductCountryID), 4, 0));
            }
            A39ProductCountryName = cgiGet( edtProductCountryName_Internalname);
            AssignAttri("", false, "A39ProductCountryName", A39ProductCountryName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORYID");
               AnyError = 1;
               GX_FocusControl = edtCategoryId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A6CategoryId = 0;
               AssignAttri("", false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
            }
            else
            {
               A6CategoryId = (short)(context.localUtil.CToN( cgiGet( edtCategoryId_Internalname), ",", "."));
               AssignAttri("", false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
            }
            A7CategoryName = cgiGet( edtCategoryName_Internalname);
            AssignAttri("", false, "A7CategoryName", A7CategoryName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SELLERID");
               AnyError = 1;
               GX_FocusControl = edtSellerId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A10SellerId = 0;
               AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            }
            else
            {
               A10SellerId = (short)(context.localUtil.CToN( cgiGet( edtSellerId_Internalname), ",", "."));
               AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            }
            A18SellerName = cgiGet( edtSellerName_Internalname);
            AssignAttri("", false, "A18SellerName", A18SellerName);
            A19SellerPhoto = cgiGet( imgSellerPhoto_Internalname);
            AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
            A8CountryId = (short)(context.localUtil.CToN( cgiGet( edtCountryId_Internalname), ",", "."));
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            A9CountryName = cgiGet( edtCountryName_Internalname);
            AssignAttri("", false, "A9CountryName", A9CountryName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgProductPhoto_Internalname, ref  A28ProductPhoto, ref  A40000ProductPhoto_GXI);
            getMultimediaValue(imgSellerPhoto_Internalname, ref  A19SellerPhoto, ref  A40001SellerPhoto_GXI);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A12ProductId = (short)(NumberUtil.Val( GetPar( "ProductId"), "."));
               AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll056( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes056( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void ZM056( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z13ProductName = T00053_A13ProductName[0];
               Z26ProductDescription = T00053_A26ProductDescription[0];
               Z27ProductPrice = T00053_A27ProductPrice[0];
               Z6CategoryId = T00053_A6CategoryId[0];
               Z10SellerId = T00053_A10SellerId[0];
               Z14ProductCountryID = T00053_A14ProductCountryID[0];
            }
            else
            {
               Z13ProductName = A13ProductName;
               Z26ProductDescription = A26ProductDescription;
               Z27ProductPrice = A27ProductPrice;
               Z6CategoryId = A6CategoryId;
               Z10SellerId = A10SellerId;
               Z14ProductCountryID = A14ProductCountryID;
            }
         }
         if ( GX_JID == -3 )
         {
            Z12ProductId = A12ProductId;
            Z13ProductName = A13ProductName;
            Z26ProductDescription = A26ProductDescription;
            Z27ProductPrice = A27ProductPrice;
            Z28ProductPhoto = A28ProductPhoto;
            Z40000ProductPhoto_GXI = A40000ProductPhoto_GXI;
            Z6CategoryId = A6CategoryId;
            Z10SellerId = A10SellerId;
            Z14ProductCountryID = A14ProductCountryID;
            Z39ProductCountryName = A39ProductCountryName;
            Z7CategoryName = A7CategoryName;
            Z18SellerName = A18SellerName;
            Z19SellerPhoto = A19SellerPhoto;
            Z40001SellerPhoto_GXI = A40001SellerPhoto_GXI;
            Z8CountryId = A8CountryId;
            Z9CountryName = A9CountryName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_14_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTCOUNTRYID"+"'), id:'"+"PRODUCTCOUNTRYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_6_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORYID"+"'), id:'"+"CATEGORYID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_10_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SELLERID"+"'), id:'"+"SELLERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load056( )
      {
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
            A13ProductName = T00058_A13ProductName[0];
            AssignAttri("", false, "A13ProductName", A13ProductName);
            A26ProductDescription = T00058_A26ProductDescription[0];
            AssignAttri("", false, "A26ProductDescription", A26ProductDescription);
            A27ProductPrice = T00058_A27ProductPrice[0];
            AssignAttri("", false, "A27ProductPrice", StringUtil.LTrimStr( A27ProductPrice, 8, 2));
            A40000ProductPhoto_GXI = T00058_A40000ProductPhoto_GXI[0];
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
            A39ProductCountryName = T00058_A39ProductCountryName[0];
            AssignAttri("", false, "A39ProductCountryName", A39ProductCountryName);
            A7CategoryName = T00058_A7CategoryName[0];
            AssignAttri("", false, "A7CategoryName", A7CategoryName);
            A18SellerName = T00058_A18SellerName[0];
            AssignAttri("", false, "A18SellerName", A18SellerName);
            A40001SellerPhoto_GXI = T00058_A40001SellerPhoto_GXI[0];
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
            A9CountryName = T00058_A9CountryName[0];
            AssignAttri("", false, "A9CountryName", A9CountryName);
            A6CategoryId = T00058_A6CategoryId[0];
            AssignAttri("", false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
            A10SellerId = T00058_A10SellerId[0];
            AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            A14ProductCountryID = T00058_A14ProductCountryID[0];
            AssignAttri("", false, "A14ProductCountryID", StringUtil.LTrimStr( (decimal)(A14ProductCountryID), 4, 0));
            A8CountryId = T00058_A8CountryId[0];
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            A28ProductPhoto = T00058_A28ProductPhoto[0];
            AssignAttri("", false, "A28ProductPhoto", A28ProductPhoto);
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
            A19SellerPhoto = T00058_A19SellerPhoto[0];
            AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
            ZM056( -3) ;
         }
         pr_default.close(6);
         OnLoadActions056( ) ;
      }

      protected void OnLoadActions056( )
      {
      }

      protected void CheckExtendedTable056( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A13ProductName, A12ProductId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A13ProductName)) )
         {
            GX_msglist.addItem("Their name cannot be empty", 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A27ProductPrice) )
         {
            GX_msglist.addItem("Their price cannot be empty", 1, "PRODUCTPRICE");
            AnyError = 1;
            GX_FocusControl = edtProductPrice_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A14ProductCountryID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country Product'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A39ProductCountryName = T00056_A39ProductCountryName[0];
         AssignAttri("", false, "A39ProductCountryName", A39ProductCountryName);
         pr_default.close(4);
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A6CategoryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A7CategoryName = T00054_A7CategoryName[0];
         AssignAttri("", false, "A7CategoryName", A7CategoryName);
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A18SellerName = T00055_A18SellerName[0];
         AssignAttri("", false, "A18SellerName", A18SellerName);
         A40001SellerPhoto_GXI = T00055_A40001SellerPhoto_GXI[0];
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
         A8CountryId = T00055_A8CountryId[0];
         AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
         A19SellerPhoto = T00055_A19SellerPhoto[0];
         AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
         pr_default.close(3);
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A9CountryName = T00057_A9CountryName[0];
         AssignAttri("", false, "A9CountryName", A9CountryName);
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors056( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( short A14ProductCountryID )
      {
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A14ProductCountryID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country Product'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A39ProductCountryName = T000510_A39ProductCountryName[0];
         AssignAttri("", false, "A39ProductCountryName", A39ProductCountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A39ProductCountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_5( short A6CategoryId )
      {
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {A6CategoryId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("Não existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A7CategoryName = T000511_A7CategoryName[0];
         AssignAttri("", false, "A7CategoryName", A7CategoryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A7CategoryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_6( short A10SellerId )
      {
         /* Using cursor T000512 */
         pr_default.execute(10, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("Não existe 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A18SellerName = T000512_A18SellerName[0];
         AssignAttri("", false, "A18SellerName", A18SellerName);
         A40001SellerPhoto_GXI = T000512_A40001SellerPhoto_GXI[0];
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
         A8CountryId = T000512_A8CountryId[0];
         AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
         A19SellerPhoto = T000512_A19SellerPhoto[0];
         AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A18SellerName))+"\""+","+"\""+GXUtil.EncodeJSConstant( A19SellerPhoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001SellerPhoto_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_8( short A8CountryId )
      {
         /* Using cursor T000513 */
         pr_default.execute(11, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A9CountryName = T000513_A9CountryName[0];
         AssignAttri("", false, "A9CountryName", A9CountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A9CountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey056( )
      {
         /* Using cursor T000514 */
         pr_default.execute(12, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM056( 3) ;
            RcdFound6 = 1;
            A12ProductId = T00053_A12ProductId[0];
            AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
            A13ProductName = T00053_A13ProductName[0];
            AssignAttri("", false, "A13ProductName", A13ProductName);
            A26ProductDescription = T00053_A26ProductDescription[0];
            AssignAttri("", false, "A26ProductDescription", A26ProductDescription);
            A27ProductPrice = T00053_A27ProductPrice[0];
            AssignAttri("", false, "A27ProductPrice", StringUtil.LTrimStr( A27ProductPrice, 8, 2));
            A40000ProductPhoto_GXI = T00053_A40000ProductPhoto_GXI[0];
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
            A6CategoryId = T00053_A6CategoryId[0];
            AssignAttri("", false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
            A10SellerId = T00053_A10SellerId[0];
            AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
            A14ProductCountryID = T00053_A14ProductCountryID[0];
            AssignAttri("", false, "A14ProductCountryID", StringUtil.LTrimStr( (decimal)(A14ProductCountryID), 4, 0));
            A28ProductPhoto = T00053_A28ProductPhoto[0];
            AssignAttri("", false, "A28ProductPhoto", A28ProductPhoto);
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
            Z12ProductId = A12ProductId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load056( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey056( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey056( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey056( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000515 */
         pr_default.execute(13, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000515_A12ProductId[0] < A12ProductId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000515_A12ProductId[0] > A12ProductId ) ) )
            {
               A12ProductId = T000515_A12ProductId[0];
               AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000516 */
         pr_default.execute(14, new Object[] {A12ProductId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000516_A12ProductId[0] > A12ProductId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000516_A12ProductId[0] < A12ProductId ) ) )
            {
               A12ProductId = T000516_A12ProductId[0];
               AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey056( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert056( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A12ProductId != Z12ProductId )
               {
                  A12ProductId = Z12ProductId;
                  AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTID");
                  AnyError = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update056( ) ;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A12ProductId != Z12ProductId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert056( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTID");
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert056( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A12ProductId != Z12ProductId )
         {
            A12ProductId = Z12ProductId;
            AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart056( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd056( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart056( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound6 != 0 )
            {
               ScanNext056( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd056( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency056( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A12ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z13ProductName, T00052_A13ProductName[0]) != 0 ) || ( StringUtil.StrCmp(Z26ProductDescription, T00052_A26ProductDescription[0]) != 0 ) || ( Z27ProductPrice != T00052_A27ProductPrice[0] ) || ( Z6CategoryId != T00052_A6CategoryId[0] ) || ( Z10SellerId != T00052_A10SellerId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z14ProductCountryID != T00052_A14ProductCountryID[0] ) )
            {
               if ( StringUtil.StrCmp(Z13ProductName, T00052_A13ProductName[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductName");
                  GXUtil.WriteLogRaw("Old: ",Z13ProductName);
                  GXUtil.WriteLogRaw("Current: ",T00052_A13ProductName[0]);
               }
               if ( StringUtil.StrCmp(Z26ProductDescription, T00052_A26ProductDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductDescription");
                  GXUtil.WriteLogRaw("Old: ",Z26ProductDescription);
                  GXUtil.WriteLogRaw("Current: ",T00052_A26ProductDescription[0]);
               }
               if ( Z27ProductPrice != T00052_A27ProductPrice[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductPrice");
                  GXUtil.WriteLogRaw("Old: ",Z27ProductPrice);
                  GXUtil.WriteLogRaw("Current: ",T00052_A27ProductPrice[0]);
               }
               if ( Z6CategoryId != T00052_A6CategoryId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"CategoryId");
                  GXUtil.WriteLogRaw("Old: ",Z6CategoryId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A6CategoryId[0]);
               }
               if ( Z10SellerId != T00052_A10SellerId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"SellerId");
                  GXUtil.WriteLogRaw("Old: ",Z10SellerId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A10SellerId[0]);
               }
               if ( Z14ProductCountryID != T00052_A14ProductCountryID[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductCountryID");
                  GXUtil.WriteLogRaw("Old: ",Z14ProductCountryID);
                  GXUtil.WriteLogRaw("Current: ",T00052_A14ProductCountryID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM056( 0) ;
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000517 */
                     pr_default.execute(15, new Object[] {A13ProductName, A26ProductDescription, A27ProductPrice, A28ProductPhoto, A40000ProductPhoto_GXI, A6CategoryId, A10SellerId, A14ProductCountryID});
                     A12ProductId = T000517_A12ProductId[0];
                     AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("Product");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load056( ) ;
            }
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void Update056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000518 */
                     pr_default.execute(16, new Object[] {A13ProductName, A26ProductDescription, A27ProductPrice, A6CategoryId, A10SellerId, A14ProductCountryID, A12ProductId});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate056( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption050( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void DeferredUpdate056( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000519 */
            pr_default.execute(17, new Object[] {A28ProductPhoto, A40000ProductPhoto_GXI, A12ProductId});
            pr_default.close(17);
            dsDefault.SmartCacheProvider.SetUpdated("Product");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls056( ) ;
            AfterConfirm056( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete056( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000520 */
                  pr_default.execute(18, new Object[] {A12ProductId});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound6 == 0 )
                        {
                           InitAll056( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption050( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel056( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls056( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000521 */
            pr_default.execute(19, new Object[] {A14ProductCountryID});
            A39ProductCountryName = T000521_A39ProductCountryName[0];
            AssignAttri("", false, "A39ProductCountryName", A39ProductCountryName);
            pr_default.close(19);
            /* Using cursor T000522 */
            pr_default.execute(20, new Object[] {A6CategoryId});
            A7CategoryName = T000522_A7CategoryName[0];
            AssignAttri("", false, "A7CategoryName", A7CategoryName);
            pr_default.close(20);
            /* Using cursor T000523 */
            pr_default.execute(21, new Object[] {A10SellerId});
            A18SellerName = T000523_A18SellerName[0];
            AssignAttri("", false, "A18SellerName", A18SellerName);
            A40001SellerPhoto_GXI = T000523_A40001SellerPhoto_GXI[0];
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
            A8CountryId = T000523_A8CountryId[0];
            AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
            A19SellerPhoto = T000523_A19SellerPhoto[0];
            AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
            AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
            AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
            pr_default.close(21);
            /* Using cursor T000524 */
            pr_default.execute(22, new Object[] {A8CountryId});
            A9CountryName = T000524_A9CountryName[0];
            AssignAttri("", false, "A9CountryName", A9CountryName);
            pr_default.close(22);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000525 */
            pr_default.execute(23, new Object[] {A12ProductId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ShoppingCartProduct"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000526 */
            pr_default.execute(24, new Object[] {A12ProductId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel056( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete056( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(22);
            context.CommitDataStores("product",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(22);
            context.RollbackDataStores("product",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart056( )
      {
         /* Using cursor T000527 */
         pr_default.execute(25);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound6 = 1;
            A12ProductId = T000527_A12ProductId[0];
            AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext056( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound6 = 1;
            A12ProductId = T000527_A12ProductId[0];
            AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
         }
      }

      protected void ScanEnd056( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm056( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert056( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate056( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete056( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete056( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate056( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes056( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
         edtProductDescription_Enabled = 0;
         AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), true);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), true);
         imgProductPhoto_Enabled = 0;
         AssignProp("", false, imgProductPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductPhoto_Enabled), 5, 0), true);
         edtProductCountryID_Enabled = 0;
         AssignProp("", false, edtProductCountryID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCountryID_Enabled), 5, 0), true);
         edtProductCountryName_Enabled = 0;
         AssignProp("", false, edtProductCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCountryName_Enabled), 5, 0), true);
         edtCategoryId_Enabled = 0;
         AssignProp("", false, edtCategoryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryId_Enabled), 5, 0), true);
         edtCategoryName_Enabled = 0;
         AssignProp("", false, edtCategoryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoryName_Enabled), 5, 0), true);
         edtSellerId_Enabled = 0;
         AssignProp("", false, edtSellerId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerId_Enabled), 5, 0), true);
         edtSellerName_Enabled = 0;
         AssignProp("", false, edtSellerName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSellerName_Enabled), 5, 0), true);
         imgSellerPhoto_Enabled = 0;
         AssignProp("", false, imgSellerPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgSellerPhoto_Enabled), 5, 0), true);
         edtCountryId_Enabled = 0;
         AssignProp("", false, edtCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryId_Enabled), 5, 0), true);
         edtCountryName_Enabled = 0;
         AssignProp("", false, edtCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCountryName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes056( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
      {
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 204480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 204480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202351822453245", false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("product.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z12ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ProductId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13ProductName", StringUtil.RTrim( Z13ProductName));
         GxWebStd.gx_hidden_field( context, "Z26ProductDescription", StringUtil.RTrim( Z26ProductDescription));
         GxWebStd.gx_hidden_field( context, "Z27ProductPrice", StringUtil.LTrim( StringUtil.NToC( Z27ProductPrice, 8, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z6CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6CategoryId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z10SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10SellerId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z14ProductCountryID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14ProductCountryID), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PRODUCTPHOTO_GXI", A40000ProductPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "SELLERPHOTO_GXI", A40001SellerPhoto_GXI);
         GXCCtlgxBlob = "PRODUCTPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A28ProductPhoto);
         GXCCtlgxBlob = "SELLERPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A19SellerPhoto);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("product.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Product" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product" ;
      }

      protected void InitializeNonKey056( )
      {
         A13ProductName = "";
         AssignAttri("", false, "A13ProductName", A13ProductName);
         A26ProductDescription = "";
         AssignAttri("", false, "A26ProductDescription", A26ProductDescription);
         A27ProductPrice = 0;
         AssignAttri("", false, "A27ProductPrice", StringUtil.LTrimStr( A27ProductPrice, 8, 2));
         A28ProductPhoto = "";
         AssignAttri("", false, "A28ProductPhoto", A28ProductPhoto);
         AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), true);
         AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
         A40000ProductPhoto_GXI = "";
         AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A28ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A28ProductPhoto))), true);
         AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A28ProductPhoto), true);
         A14ProductCountryID = 0;
         AssignAttri("", false, "A14ProductCountryID", StringUtil.LTrimStr( (decimal)(A14ProductCountryID), 4, 0));
         A39ProductCountryName = "";
         AssignAttri("", false, "A39ProductCountryName", A39ProductCountryName);
         A6CategoryId = 0;
         AssignAttri("", false, "A6CategoryId", StringUtil.LTrimStr( (decimal)(A6CategoryId), 4, 0));
         A7CategoryName = "";
         AssignAttri("", false, "A7CategoryName", A7CategoryName);
         A10SellerId = 0;
         AssignAttri("", false, "A10SellerId", StringUtil.LTrimStr( (decimal)(A10SellerId), 4, 0));
         A18SellerName = "";
         AssignAttri("", false, "A18SellerName", A18SellerName);
         A19SellerPhoto = "";
         AssignAttri("", false, "A19SellerPhoto", A19SellerPhoto);
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
         A40001SellerPhoto_GXI = "";
         AssignProp("", false, imgSellerPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A19SellerPhoto)) ? A40001SellerPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A19SellerPhoto))), true);
         AssignProp("", false, imgSellerPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A19SellerPhoto), true);
         A8CountryId = 0;
         AssignAttri("", false, "A8CountryId", StringUtil.LTrimStr( (decimal)(A8CountryId), 4, 0));
         A9CountryName = "";
         AssignAttri("", false, "A9CountryName", A9CountryName);
         Z13ProductName = "";
         Z26ProductDescription = "";
         Z27ProductPrice = 0;
         Z6CategoryId = 0;
         Z10SellerId = 0;
         Z14ProductCountryID = 0;
      }

      protected void InitAll056( )
      {
         A12ProductId = 0;
         AssignAttri("", false, "A12ProductId", StringUtil.LTrimStr( (decimal)(A12ProductId), 4, 0));
         InitializeNonKey056( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202351822453272", true, true);
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
         context.AddJavascriptSource("product.js", "?202351822453273", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         imgProductPhoto_Internalname = "PRODUCTPHOTO";
         edtProductCountryID_Internalname = "PRODUCTCOUNTRYID";
         edtProductCountryName_Internalname = "PRODUCTCOUNTRYNAME";
         edtCategoryId_Internalname = "CATEGORYID";
         edtCategoryName_Internalname = "CATEGORYNAME";
         edtSellerId_Internalname = "SELLERID";
         edtSellerName_Internalname = "SELLERNAME";
         imgSellerPhoto_Internalname = "SELLERPHOTO";
         edtCountryId_Internalname = "COUNTRYID";
         edtCountryName_Internalname = "COUNTRYNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_14_Internalname = "PROMPT_14";
         imgprompt_6_Internalname = "PROMPT_6";
         imgprompt_10_Internalname = "PROMPT_10";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Product";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         edtCountryId_Jsonclick = "";
         edtCountryId_Enabled = 0;
         imgSellerPhoto_Enabled = 0;
         edtSellerName_Jsonclick = "";
         edtSellerName_Enabled = 0;
         imgprompt_10_Visible = 1;
         imgprompt_10_Link = "";
         edtSellerId_Jsonclick = "";
         edtSellerId_Enabled = 1;
         edtCategoryName_Jsonclick = "";
         edtCategoryName_Enabled = 0;
         imgprompt_6_Visible = 1;
         imgprompt_6_Link = "";
         edtCategoryId_Jsonclick = "";
         edtCategoryId_Enabled = 1;
         edtProductCountryName_Jsonclick = "";
         edtProductCountryName_Enabled = 0;
         imgprompt_14_Visible = 1;
         imgprompt_14_Link = "";
         edtProductCountryID_Jsonclick = "";
         edtProductCountryID_Enabled = 1;
         imgProductPhoto_Enabled = 1;
         edtProductPrice_Jsonclick = "";
         edtProductPrice_Enabled = 1;
         edtProductDescription_Jsonclick = "";
         edtProductDescription_Enabled = 1;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 1;
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtProductName_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Productid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A13ProductName", StringUtil.RTrim( A13ProductName));
         AssignAttri("", false, "A26ProductDescription", StringUtil.RTrim( A26ProductDescription));
         AssignAttri("", false, "A27ProductPrice", StringUtil.LTrim( StringUtil.NToC( A27ProductPrice, 8, 2, ".", "")));
         AssignAttri("", false, "A28ProductPhoto", context.PathToRelativeUrl( A28ProductPhoto));
         GXCCtlgxBlob = "PRODUCTPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A28ProductPhoto));
         AssignAttri("", false, "A40000ProductPhoto_GXI", A40000ProductPhoto_GXI);
         AssignAttri("", false, "A14ProductCountryID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14ProductCountryID), 4, 0, ".", "")));
         AssignAttri("", false, "A6CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6CategoryId), 4, 0, ".", "")));
         AssignAttri("", false, "A10SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SellerId), 4, 0, ".", "")));
         AssignAttri("", false, "A39ProductCountryName", StringUtil.RTrim( A39ProductCountryName));
         AssignAttri("", false, "A7CategoryName", StringUtil.RTrim( A7CategoryName));
         AssignAttri("", false, "A18SellerName", StringUtil.RTrim( A18SellerName));
         AssignAttri("", false, "A19SellerPhoto", context.PathToRelativeUrl( A19SellerPhoto));
         GXCCtlgxBlob = "SELLERPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A19SellerPhoto));
         AssignAttri("", false, "A40001SellerPhoto_GXI", A40001SellerPhoto_GXI);
         AssignAttri("", false, "A8CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A9CountryName", StringUtil.RTrim( A9CountryName));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z12ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ProductId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z13ProductName", StringUtil.RTrim( Z13ProductName));
         GxWebStd.gx_hidden_field( context, "Z26ProductDescription", StringUtil.RTrim( Z26ProductDescription));
         GxWebStd.gx_hidden_field( context, "Z27ProductPrice", StringUtil.LTrim( StringUtil.NToC( Z27ProductPrice, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28ProductPhoto", context.PathToRelativeUrl( Z28ProductPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000ProductPhoto_GXI", Z40000ProductPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z14ProductCountryID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14ProductCountryID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z6CategoryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6CategoryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10SellerId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10SellerId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z39ProductCountryName", StringUtil.RTrim( Z39ProductCountryName));
         GxWebStd.gx_hidden_field( context, "Z7CategoryName", StringUtil.RTrim( Z7CategoryName));
         GxWebStd.gx_hidden_field( context, "Z18SellerName", StringUtil.RTrim( Z18SellerName));
         GxWebStd.gx_hidden_field( context, "Z19SellerPhoto", context.PathToRelativeUrl( Z19SellerPhoto));
         GxWebStd.gx_hidden_field( context, "Z40001SellerPhoto_GXI", Z40001SellerPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z8CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z9CountryName", StringUtil.RTrim( Z9CountryName));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Productname( )
      {
         /* Using cursor T000528 */
         pr_default.execute(26, new Object[] {A13ProductName, A12ProductId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"}), 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
         }
         pr_default.close(26);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A13ProductName)) )
         {
            GX_msglist.addItem("Their name cannot be empty", 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Productcountryid( )
      {
         /* Using cursor T000521 */
         pr_default.execute(19, new Object[] {A14ProductCountryID});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country Product'.", "ForeignKeyNotFound", 1, "PRODUCTCOUNTRYID");
            AnyError = 1;
            GX_FocusControl = edtProductCountryID_Internalname;
         }
         A39ProductCountryName = T000521_A39ProductCountryName[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A39ProductCountryName", StringUtil.RTrim( A39ProductCountryName));
      }

      public void Valid_Categoryid( )
      {
         /* Using cursor T000522 */
         pr_default.execute(20, new Object[] {A6CategoryId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("Não existe 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
            AnyError = 1;
            GX_FocusControl = edtCategoryId_Internalname;
         }
         A7CategoryName = T000522_A7CategoryName[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A7CategoryName", StringUtil.RTrim( A7CategoryName));
      }

      public void Valid_Sellerid( )
      {
         /* Using cursor T000523 */
         pr_default.execute(21, new Object[] {A10SellerId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("Não existe 'Seller'.", "ForeignKeyNotFound", 1, "SELLERID");
            AnyError = 1;
            GX_FocusControl = edtSellerId_Internalname;
         }
         A18SellerName = T000523_A18SellerName[0];
         A40001SellerPhoto_GXI = T000523_A40001SellerPhoto_GXI[0];
         A8CountryId = T000523_A8CountryId[0];
         A19SellerPhoto = T000523_A19SellerPhoto[0];
         pr_default.close(21);
         /* Using cursor T000524 */
         pr_default.execute(22, new Object[] {A8CountryId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("Não existe 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A9CountryName = T000524_A9CountryName[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A18SellerName", StringUtil.RTrim( A18SellerName));
         AssignAttri("", false, "A19SellerPhoto", context.PathToRelativeUrl( A19SellerPhoto));
         GXCCtlgxBlob = "SELLERPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A19SellerPhoto));
         AssignAttri("", false, "A40001SellerPhoto_GXI", A40001SellerPhoto_GXI);
         AssignAttri("", false, "A8CountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8CountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A9CountryName", StringUtil.RTrim( A9CountryName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A12ProductId',fld:'PRODUCTID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A13ProductName',fld:'PRODUCTNAME',pic:''},{av:'A26ProductDescription',fld:'PRODUCTDESCRIPTION',pic:''},{av:'A27ProductPrice',fld:'PRODUCTPRICE',pic:'$ ZZZZ9.99'},{av:'A28ProductPhoto',fld:'PRODUCTPHOTO',pic:''},{av:'A40000ProductPhoto_GXI',fld:'PRODUCTPHOTO_GXI',pic:''},{av:'A14ProductCountryID',fld:'PRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'A6CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A10SellerId',fld:'SELLERID',pic:'ZZZ9'},{av:'A39ProductCountryName',fld:'PRODUCTCOUNTRYNAME',pic:''},{av:'A7CategoryName',fld:'CATEGORYNAME',pic:''},{av:'A18SellerName',fld:'SELLERNAME',pic:''},{av:'A19SellerPhoto',fld:'SELLERPHOTO',pic:''},{av:'A40001SellerPhoto_GXI',fld:'SELLERPHOTO_GXI',pic:''},{av:'A8CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A9CountryName',fld:'COUNTRYNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z12ProductId'},{av:'Z13ProductName'},{av:'Z26ProductDescription'},{av:'Z27ProductPrice'},{av:'Z28ProductPhoto'},{av:'Z40000ProductPhoto_GXI'},{av:'Z14ProductCountryID'},{av:'Z6CategoryId'},{av:'Z10SellerId'},{av:'Z39ProductCountryName'},{av:'Z7CategoryName'},{av:'Z18SellerName'},{av:'Z19SellerPhoto'},{av:'Z40001SellerPhoto_GXI'},{av:'Z8CountryId'},{av:'Z9CountryName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODUCTNAME","{handler:'Valid_Productname',iparms:[{av:'A13ProductName',fld:'PRODUCTNAME',pic:''},{av:'A12ProductId',fld:'PRODUCTID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PRODUCTNAME",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTPRICE","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOUNTRYID","{handler:'Valid_Productcountryid',iparms:[{av:'A14ProductCountryID',fld:'PRODUCTCOUNTRYID',pic:'ZZZ9'},{av:'A39ProductCountryName',fld:'PRODUCTCOUNTRYNAME',pic:''}]");
         setEventMetadata("VALID_PRODUCTCOUNTRYID",",oparms:[{av:'A39ProductCountryName',fld:'PRODUCTCOUNTRYNAME',pic:''}]}");
         setEventMetadata("VALID_CATEGORYID","{handler:'Valid_Categoryid',iparms:[{av:'A6CategoryId',fld:'CATEGORYID',pic:'ZZZ9'},{av:'A7CategoryName',fld:'CATEGORYNAME',pic:''}]");
         setEventMetadata("VALID_CATEGORYID",",oparms:[{av:'A7CategoryName',fld:'CATEGORYNAME',pic:''}]}");
         setEventMetadata("VALID_SELLERID","{handler:'Valid_Sellerid',iparms:[{av:'A10SellerId',fld:'SELLERID',pic:'ZZZ9'},{av:'A8CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A18SellerName',fld:'SELLERNAME',pic:''},{av:'A19SellerPhoto',fld:'SELLERPHOTO',pic:''},{av:'A40001SellerPhoto_GXI',fld:'SELLERPHOTO_GXI',pic:''},{av:'A9CountryName',fld:'COUNTRYNAME',pic:''}]");
         setEventMetadata("VALID_SELLERID",",oparms:[{av:'A18SellerName',fld:'SELLERNAME',pic:''},{av:'A19SellerPhoto',fld:'SELLERPHOTO',pic:''},{av:'A40001SellerPhoto_GXI',fld:'SELLERPHOTO_GXI',pic:''},{av:'A8CountryId',fld:'COUNTRYID',pic:'ZZZ9'},{av:'A9CountryName',fld:'COUNTRYNAME',pic:''}]}");
         setEventMetadata("VALID_COUNTRYID","{handler:'Valid_Countryid',iparms:[]");
         setEventMetadata("VALID_COUNTRYID",",oparms:[]}");
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
         pr_default.close(1);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(19);
         pr_default.close(22);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z13ProductName = "";
         Z26ProductDescription = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A13ProductName = "";
         A26ProductDescription = "";
         A28ProductPhoto = "";
         A40000ProductPhoto_GXI = "";
         sImgUrl = "";
         A39ProductCountryName = "";
         A7CategoryName = "";
         A18SellerName = "";
         A19SellerPhoto = "";
         A40001SellerPhoto_GXI = "";
         A9CountryName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z28ProductPhoto = "";
         Z40000ProductPhoto_GXI = "";
         Z39ProductCountryName = "";
         Z7CategoryName = "";
         Z18SellerName = "";
         Z19SellerPhoto = "";
         Z40001SellerPhoto_GXI = "";
         Z9CountryName = "";
         T00058_A12ProductId = new short[1] ;
         T00058_A13ProductName = new string[] {""} ;
         T00058_A26ProductDescription = new string[] {""} ;
         T00058_A27ProductPrice = new decimal[1] ;
         T00058_A40000ProductPhoto_GXI = new string[] {""} ;
         T00058_A39ProductCountryName = new string[] {""} ;
         T00058_A7CategoryName = new string[] {""} ;
         T00058_A18SellerName = new string[] {""} ;
         T00058_A40001SellerPhoto_GXI = new string[] {""} ;
         T00058_A9CountryName = new string[] {""} ;
         T00058_A6CategoryId = new short[1] ;
         T00058_A10SellerId = new short[1] ;
         T00058_A14ProductCountryID = new short[1] ;
         T00058_A8CountryId = new short[1] ;
         T00058_A28ProductPhoto = new string[] {""} ;
         T00058_A19SellerPhoto = new string[] {""} ;
         T00059_A13ProductName = new string[] {""} ;
         T00056_A39ProductCountryName = new string[] {""} ;
         T00054_A7CategoryName = new string[] {""} ;
         T00055_A18SellerName = new string[] {""} ;
         T00055_A40001SellerPhoto_GXI = new string[] {""} ;
         T00055_A8CountryId = new short[1] ;
         T00055_A19SellerPhoto = new string[] {""} ;
         T00057_A9CountryName = new string[] {""} ;
         T000510_A39ProductCountryName = new string[] {""} ;
         T000511_A7CategoryName = new string[] {""} ;
         T000512_A18SellerName = new string[] {""} ;
         T000512_A40001SellerPhoto_GXI = new string[] {""} ;
         T000512_A8CountryId = new short[1] ;
         T000512_A19SellerPhoto = new string[] {""} ;
         T000513_A9CountryName = new string[] {""} ;
         T000514_A12ProductId = new short[1] ;
         T00053_A12ProductId = new short[1] ;
         T00053_A13ProductName = new string[] {""} ;
         T00053_A26ProductDescription = new string[] {""} ;
         T00053_A27ProductPrice = new decimal[1] ;
         T00053_A40000ProductPhoto_GXI = new string[] {""} ;
         T00053_A6CategoryId = new short[1] ;
         T00053_A10SellerId = new short[1] ;
         T00053_A14ProductCountryID = new short[1] ;
         T00053_A28ProductPhoto = new string[] {""} ;
         sMode6 = "";
         T000515_A12ProductId = new short[1] ;
         T000516_A12ProductId = new short[1] ;
         T00052_A12ProductId = new short[1] ;
         T00052_A13ProductName = new string[] {""} ;
         T00052_A26ProductDescription = new string[] {""} ;
         T00052_A27ProductPrice = new decimal[1] ;
         T00052_A40000ProductPhoto_GXI = new string[] {""} ;
         T00052_A6CategoryId = new short[1] ;
         T00052_A10SellerId = new short[1] ;
         T00052_A14ProductCountryID = new short[1] ;
         T00052_A28ProductPhoto = new string[] {""} ;
         T000517_A12ProductId = new short[1] ;
         T000521_A39ProductCountryName = new string[] {""} ;
         T000522_A7CategoryName = new string[] {""} ;
         T000523_A18SellerName = new string[] {""} ;
         T000523_A40001SellerPhoto_GXI = new string[] {""} ;
         T000523_A8CountryId = new short[1] ;
         T000523_A19SellerPhoto = new string[] {""} ;
         T000524_A9CountryName = new string[] {""} ;
         T000525_A16ShoppingCartId = new short[1] ;
         T000525_A12ProductId = new short[1] ;
         T000526_A15PromotionId = new short[1] ;
         T000526_A12ProductId = new short[1] ;
         T000527_A12ProductId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ13ProductName = "";
         ZZ26ProductDescription = "";
         ZZ28ProductPhoto = "";
         ZZ40000ProductPhoto_GXI = "";
         ZZ39ProductCountryName = "";
         ZZ7CategoryName = "";
         ZZ18SellerName = "";
         ZZ19SellerPhoto = "";
         ZZ40001SellerPhoto_GXI = "";
         ZZ9CountryName = "";
         T000528_A13ProductName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product__default(),
            new Object[][] {
                new Object[] {
               T00052_A12ProductId, T00052_A13ProductName, T00052_A26ProductDescription, T00052_A27ProductPrice, T00052_A40000ProductPhoto_GXI, T00052_A6CategoryId, T00052_A10SellerId, T00052_A14ProductCountryID, T00052_A28ProductPhoto
               }
               , new Object[] {
               T00053_A12ProductId, T00053_A13ProductName, T00053_A26ProductDescription, T00053_A27ProductPrice, T00053_A40000ProductPhoto_GXI, T00053_A6CategoryId, T00053_A10SellerId, T00053_A14ProductCountryID, T00053_A28ProductPhoto
               }
               , new Object[] {
               T00054_A7CategoryName
               }
               , new Object[] {
               T00055_A18SellerName, T00055_A40001SellerPhoto_GXI, T00055_A8CountryId, T00055_A19SellerPhoto
               }
               , new Object[] {
               T00056_A39ProductCountryName
               }
               , new Object[] {
               T00057_A9CountryName
               }
               , new Object[] {
               T00058_A12ProductId, T00058_A13ProductName, T00058_A26ProductDescription, T00058_A27ProductPrice, T00058_A40000ProductPhoto_GXI, T00058_A39ProductCountryName, T00058_A7CategoryName, T00058_A18SellerName, T00058_A40001SellerPhoto_GXI, T00058_A9CountryName,
               T00058_A6CategoryId, T00058_A10SellerId, T00058_A14ProductCountryID, T00058_A8CountryId, T00058_A28ProductPhoto, T00058_A19SellerPhoto
               }
               , new Object[] {
               T00059_A13ProductName
               }
               , new Object[] {
               T000510_A39ProductCountryName
               }
               , new Object[] {
               T000511_A7CategoryName
               }
               , new Object[] {
               T000512_A18SellerName, T000512_A40001SellerPhoto_GXI, T000512_A8CountryId, T000512_A19SellerPhoto
               }
               , new Object[] {
               T000513_A9CountryName
               }
               , new Object[] {
               T000514_A12ProductId
               }
               , new Object[] {
               T000515_A12ProductId
               }
               , new Object[] {
               T000516_A12ProductId
               }
               , new Object[] {
               T000517_A12ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000521_A39ProductCountryName
               }
               , new Object[] {
               T000522_A7CategoryName
               }
               , new Object[] {
               T000523_A18SellerName, T000523_A40001SellerPhoto_GXI, T000523_A8CountryId, T000523_A19SellerPhoto
               }
               , new Object[] {
               T000524_A9CountryName
               }
               , new Object[] {
               T000525_A16ShoppingCartId, T000525_A12ProductId
               }
               , new Object[] {
               T000526_A15PromotionId, T000526_A12ProductId
               }
               , new Object[] {
               T000527_A12ProductId
               }
               , new Object[] {
               T000528_A13ProductName
               }
            }
         );
      }

      private short Z12ProductId ;
      private short Z6CategoryId ;
      private short Z10SellerId ;
      private short Z14ProductCountryID ;
      private short GxWebError ;
      private short A14ProductCountryID ;
      private short A6CategoryId ;
      private short A10SellerId ;
      private short A8CountryId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A12ProductId ;
      private short GX_JID ;
      private short Z8CountryId ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ12ProductId ;
      private short ZZ14ProductCountryID ;
      private short ZZ6CategoryId ;
      private short ZZ10SellerId ;
      private short ZZ8CountryId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductDescription_Enabled ;
      private int edtProductPrice_Enabled ;
      private int imgProductPhoto_Enabled ;
      private int edtProductCountryID_Enabled ;
      private int imgprompt_14_Visible ;
      private int edtProductCountryName_Enabled ;
      private int edtCategoryId_Enabled ;
      private int imgprompt_6_Visible ;
      private int edtCategoryName_Enabled ;
      private int edtSellerId_Enabled ;
      private int imgprompt_10_Visible ;
      private int edtSellerName_Enabled ;
      private int imgSellerPhoto_Enabled ;
      private int edtCountryId_Enabled ;
      private int edtCountryName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z27ProductPrice ;
      private decimal A27ProductPrice ;
      private decimal ZZ27ProductPrice ;
      private string sPrefix ;
      private string Z13ProductName ;
      private string Z26ProductDescription ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Internalname ;
      private string A13ProductName ;
      private string edtProductName_Jsonclick ;
      private string edtProductDescription_Internalname ;
      private string A26ProductDescription ;
      private string edtProductDescription_Jsonclick ;
      private string edtProductPrice_Internalname ;
      private string edtProductPrice_Jsonclick ;
      private string imgProductPhoto_Internalname ;
      private string sImgUrl ;
      private string edtProductCountryID_Internalname ;
      private string edtProductCountryID_Jsonclick ;
      private string imgprompt_14_Internalname ;
      private string imgprompt_14_Link ;
      private string edtProductCountryName_Internalname ;
      private string A39ProductCountryName ;
      private string edtProductCountryName_Jsonclick ;
      private string edtCategoryId_Internalname ;
      private string edtCategoryId_Jsonclick ;
      private string imgprompt_6_Internalname ;
      private string imgprompt_6_Link ;
      private string edtCategoryName_Internalname ;
      private string A7CategoryName ;
      private string edtCategoryName_Jsonclick ;
      private string edtSellerId_Internalname ;
      private string edtSellerId_Jsonclick ;
      private string imgprompt_10_Internalname ;
      private string imgprompt_10_Link ;
      private string edtSellerName_Internalname ;
      private string A18SellerName ;
      private string edtSellerName_Jsonclick ;
      private string imgSellerPhoto_Internalname ;
      private string edtCountryId_Internalname ;
      private string edtCountryId_Jsonclick ;
      private string edtCountryName_Internalname ;
      private string A9CountryName ;
      private string edtCountryName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z39ProductCountryName ;
      private string Z7CategoryName ;
      private string Z18SellerName ;
      private string Z9CountryName ;
      private string sMode6 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ13ProductName ;
      private string ZZ26ProductDescription ;
      private string ZZ39ProductCountryName ;
      private string ZZ7CategoryName ;
      private string ZZ18SellerName ;
      private string ZZ9CountryName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A28ProductPhoto_IsBlob ;
      private bool A19SellerPhoto_IsBlob ;
      private bool Gx_longc ;
      private string A40000ProductPhoto_GXI ;
      private string A40001SellerPhoto_GXI ;
      private string Z40000ProductPhoto_GXI ;
      private string Z40001SellerPhoto_GXI ;
      private string ZZ40000ProductPhoto_GXI ;
      private string ZZ40001SellerPhoto_GXI ;
      private string A28ProductPhoto ;
      private string A19SellerPhoto ;
      private string Z28ProductPhoto ;
      private string Z19SellerPhoto ;
      private string ZZ28ProductPhoto ;
      private string ZZ19SellerPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00058_A12ProductId ;
      private string[] T00058_A13ProductName ;
      private string[] T00058_A26ProductDescription ;
      private decimal[] T00058_A27ProductPrice ;
      private string[] T00058_A40000ProductPhoto_GXI ;
      private string[] T00058_A39ProductCountryName ;
      private string[] T00058_A7CategoryName ;
      private string[] T00058_A18SellerName ;
      private string[] T00058_A40001SellerPhoto_GXI ;
      private string[] T00058_A9CountryName ;
      private short[] T00058_A6CategoryId ;
      private short[] T00058_A10SellerId ;
      private short[] T00058_A14ProductCountryID ;
      private short[] T00058_A8CountryId ;
      private string[] T00058_A28ProductPhoto ;
      private string[] T00058_A19SellerPhoto ;
      private string[] T00059_A13ProductName ;
      private string[] T00056_A39ProductCountryName ;
      private string[] T00054_A7CategoryName ;
      private string[] T00055_A18SellerName ;
      private string[] T00055_A40001SellerPhoto_GXI ;
      private short[] T00055_A8CountryId ;
      private string[] T00055_A19SellerPhoto ;
      private string[] T00057_A9CountryName ;
      private string[] T000510_A39ProductCountryName ;
      private string[] T000511_A7CategoryName ;
      private string[] T000512_A18SellerName ;
      private string[] T000512_A40001SellerPhoto_GXI ;
      private short[] T000512_A8CountryId ;
      private string[] T000512_A19SellerPhoto ;
      private string[] T000513_A9CountryName ;
      private short[] T000514_A12ProductId ;
      private short[] T00053_A12ProductId ;
      private string[] T00053_A13ProductName ;
      private string[] T00053_A26ProductDescription ;
      private decimal[] T00053_A27ProductPrice ;
      private string[] T00053_A40000ProductPhoto_GXI ;
      private short[] T00053_A6CategoryId ;
      private short[] T00053_A10SellerId ;
      private short[] T00053_A14ProductCountryID ;
      private string[] T00053_A28ProductPhoto ;
      private short[] T000515_A12ProductId ;
      private short[] T000516_A12ProductId ;
      private short[] T00052_A12ProductId ;
      private string[] T00052_A13ProductName ;
      private string[] T00052_A26ProductDescription ;
      private decimal[] T00052_A27ProductPrice ;
      private string[] T00052_A40000ProductPhoto_GXI ;
      private short[] T00052_A6CategoryId ;
      private short[] T00052_A10SellerId ;
      private short[] T00052_A14ProductCountryID ;
      private string[] T00052_A28ProductPhoto ;
      private short[] T000517_A12ProductId ;
      private string[] T000521_A39ProductCountryName ;
      private string[] T000522_A7CategoryName ;
      private string[] T000523_A18SellerName ;
      private string[] T000523_A40001SellerPhoto_GXI ;
      private short[] T000523_A8CountryId ;
      private string[] T000523_A19SellerPhoto ;
      private string[] T000524_A9CountryName ;
      private short[] T000525_A16ShoppingCartId ;
      private short[] T000525_A12ProductId ;
      private short[] T000526_A15PromotionId ;
      private short[] T000526_A12ProductId ;
      private short[] T000527_A12ProductId ;
      private string[] T000528_A13ProductName ;
      private GXWebForm Form ;
   }

   public class product__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@ProductCountryID",GXType.Int16,4,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@ProductCountryID",GXType.Int16,4,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductDescription",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=3, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryID",GXType.Int16,4,0)
          };
          Object[] prmT000518;
          prmT000518 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductDescription",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,8,2) ,
          new ParDef("@CategoryId",GXType.Int16,4,0) ,
          new ParDef("@SellerId",GXType.Int16,4,0) ,
          new ParDef("@ProductCountryID",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000519;
          prmT000519 = new Object[] {
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000520;
          prmT000520 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000525;
          prmT000525 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000526;
          prmT000526 = new Object[] {
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000527;
          prmT000527 = new Object[] {
          };
          Object[] prmT000528;
          prmT000528 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,20,0) ,
          new ParDef("@ProductId",GXType.Int16,4,0)
          };
          Object[] prmT000521;
          prmT000521 = new Object[] {
          new ParDef("@ProductCountryID",GXType.Int16,4,0)
          };
          Object[] prmT000522;
          prmT000522 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0)
          };
          Object[] prmT000523;
          prmT000523 = new Object[] {
          new ParDef("@SellerId",GXType.Int16,4,0)
          };
          Object[] prmT000524;
          prmT000524 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductPhoto_GXI], [CategoryId], [SellerId], [ProductCountryID] AS ProductCountryID, [ProductPhoto] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [ProductId], [ProductName], [ProductDescription], [ProductPrice], [ProductPhoto_GXI], [CategoryId], [SellerId], [ProductCountryID] AS ProductCountryID, [ProductPhoto] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT TM1.[ProductId], TM1.[ProductName], TM1.[ProductDescription], TM1.[ProductPrice], TM1.[ProductPhoto_GXI], T2.[CountryName] AS ProductCountryName, T3.[CategoryName], T4.[SellerName], T4.[SellerPhoto_GXI], T5.[CountryName], TM1.[CategoryId], TM1.[SellerId], TM1.[ProductCountryID] AS ProductCountryID, T4.[CountryId], TM1.[ProductPhoto], T4.[SellerPhoto] FROM (((([Product] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[ProductCountryID]) INNER JOIN [Category] T3 ON T3.[CategoryId] = TM1.[CategoryId]) INNER JOIN [Seller] T4 ON T4.[SellerId] = TM1.[SellerId]) INNER JOIN [Country] T5 ON T5.[CountryId] = T4.[CountryId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000511", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000512", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000513", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000514", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000515", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] > @ProductId) ORDER BY [ProductId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000516", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] < @ProductId) ORDER BY [ProductId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000517", "INSERT INTO [Product]([ProductName], [ProductDescription], [ProductPrice], [ProductPhoto], [ProductPhoto_GXI], [CategoryId], [SellerId], [ProductCountryID]) VALUES(@ProductName, @ProductDescription, @ProductPrice, @ProductPhoto, @ProductPhoto_GXI, @CategoryId, @SellerId, @ProductCountryID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000517)
             ,new CursorDef("T000518", "UPDATE [Product] SET [ProductName]=@ProductName, [ProductDescription]=@ProductDescription, [ProductPrice]=@ProductPrice, [CategoryId]=@CategoryId, [SellerId]=@SellerId, [ProductCountryID]=@ProductCountryID  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000518)
             ,new CursorDef("T000519", "UPDATE [Product] SET [ProductPhoto]=@ProductPhoto, [ProductPhoto_GXI]=@ProductPhoto_GXI  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000519)
             ,new CursorDef("T000520", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000520)
             ,new CursorDef("T000521", "SELECT [CountryName] AS ProductCountryName FROM [Country] WHERE [CountryId] = @ProductCountryID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000521,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000522", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000522,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000523", "SELECT [SellerName], [SellerPhoto_GXI], [CountryId], [SellerPhoto] FROM [Seller] WHERE [SellerId] = @SellerId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000523,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000524", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000524,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000525", "SELECT TOP 1 [ShoppingCartId], [ProductId] FROM [ShoppingCartProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000525,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000526", "SELECT TOP 1 [PromotionId], [ProductId] FROM [PromotionProduct] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000526,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000527", "SELECT [ProductId] FROM [Product] ORDER BY [ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000527,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000528", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000528,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getMultimediaUri(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((string[]) buf[14])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(9));
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                return;
       }
    }

 }

}
