   M S B A M L   `   `   `  ????E  AMyToDoDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MyToDoDemo.ExtensionMyToDoDemo.Extension  5      'clr-namespace:MyToDoDemo
MyToDoDemo  5          MyToDoDemo.Views.MainView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8	extension"clr-namespace:MyToDoDemo.Extension     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      $localclr-namespace:MyToDoDemo  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5        ? Title$  MainView??5      ! 	 Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5       ? AllowsTransparency$
 True??5         MaterialDesignPaper#???   5        MaterialDesignFont#???  5      $??13(?5      $??Regular"?5        MaterialDesignBody#???  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5         TextRenderingMode$
 Auto=?5       ? WindowStartupLocation$ CenterScreen=?5       ? WindowStyle$
 None=?5      .??5      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 
dialogHost??5   	      DialogTheme$ Inherit=?5   	   	   
Identifier$	 
RootDialog??5   	   
   SnackbarMessageQueue
 5   	   ??  ?? ElementName$ MainSnackbar?? ?? Path$ MessageQueue?.??5!   
   )  #MaterialDesignThemes.Wpf.DrawerHost  -   5          Name$ 
leftDrawer??5!   $      IsLeftDrawerOpen 68   ?? $ MenuToggleButton??$ 	IsChecked?   LeftDrawerContent 5#      ]? 5$      $	??220??6   .+?5%      ?? $
??0,20q?6!   $	??Top=?6/   .+?5&      ?? $??50??5'      $??50??5(      $ ??/Sources/Images/头像.jpg??5)       J? Clip 5*      @? 5+   "    @? Center$ 25,25&?5,   %    @? RadiusX$ 25Q?5-   %    @? RadiusY$ 25Q?5.   %   50      ?? 51      $??0,10,0,0q?52      $??Center=?53      $??	周大生??54      55      ?? 57      -   5         ??Name$ menuList??58        MyListBoxItemStyle#??[ 59      ??5:      ?? *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5<      +  %Microsoft.Xaml.Behaviors.EventTrigger  5=         	EventName$ SelectionChanged??6-   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5>   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   ?? *NavigateCommand+   CommandParameter 6\   ?? $ menuList??$ SelectedItem?5?      ??5A      ?? 5B      .R?5C   "   ?? $??Center=?5D   %   
??????  ?? Orientation$ 
Horizontal=?5F   %   .+?5G   &   '	  !MaterialDesignThemes.Wpf.PackIcon	  $
??10,0q?6>    	  Kind 6L   ?? *Icon+?? 5H   &   $
??10,0q?60   ??6>   ?? *Title+5I   #   5J      5L      5M      .??5P      ]? .+?5R      (
  "MaterialDesignThemes.Wpf.ColorZone
  -   5         
 Name$ 	RibbonBar??5S      $??16q?5T      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=?5U      $	??Top=?5V       
  Mode$ 
PrimaryMid=?5W      .??5X      ]? $??False??6    .+?5Y      ?? 
?????? $ 
Horizontal=?6>   .+?5[      d? -   5         d?Name$ MenuToggleButton??5\   !   4  .System.Windows.Automation.AutomationProperties    Name$  HamburgerToggleButton??5]   !   ! d? 	IsChecked$! FalseY?5^   !    ' #MaterialDesignHamburgerToggleButton#??[ 5_   !   ?? 5a      $??24,0,0,0q?5b   !     MaterialDesignToolButton#??[ 5h   !   " ? ToolTip$" Previous Item??5i   !   +  %MaterialDesignThemes.Wpf.RippleAssist#   Feedback# 5c   !   ?? $ ?? RelativeSource$ ?? *Self+$ 
Foreground?  BrushRoundConverter% ?? 	Converter#% [ ??5d   !   ?? *GoForwardCommand+??5e   !   0  *MaterialDesignThemes.Wpf.PackIconExtension  &   Kind$& 	ArrowLeft=?'   Size' 24??5g   !   ?? $ ?? ( ?? AncestorType"( ?$ (TextElement.Foreground)?5i   !   ?? 5k      $??16,0,0,0q?5l   !   #??[ 5r   !   $" 	Next Item??5s   !   # 5m   !   ?? $ ?? *Self+$ 
Foreground?#% [ ??5n   !   ?? *GoBackCommand+??5o   !     $& 
ArrowRight=?' 24??5q   !   ?? $ ?? "( ?$ (TextElement.Foreground)?5s   !   ?? 5u      $??16,0,0,0q?5v   !   #??[ 5|   !   $
" Home??5}   !   # 5w   !   ?? $ ?? *Self+$ 
Foreground?#% [ ??5x   !   ?? *HomeCommand+??5y   !     $
& Home=?' 24??5{   !   ?? $ ?? "( ?$ (TextElement.Foreground)?5}   !   5~      ?? 5?      -   5        ) ??Name$) Title??5?      $	??320??5?      * ?? Padding$* 	120,0,0,0q?5?      $??Center=?5?      $??Center=?5?      $%  Material Design In XAML Toolkit??5?      $
??Left=?5?      $??22(?5?      $??My To Do??5?      ?? 5?      $??
-170,0,0,0q?5?      $??Right=?5?      $ 
Horizontal=?5?      .+?5?      ?? $??25??5?   !   $??25??5?   !   $
??16,0q?5?   !   $ ??/Sources/Images/头像.jpg??5?   !    5?   "   @? 5?   &   $ 	12.5,12.5&?5?   )   $
 12.5Q?5?   )   $
 12.5Q?5?   )   5?      ?? 5?      -   5        + ??Name$+ minimumButton??5?   !   $
??16,0q?5?   !   $" 	最小化??5?   !   ??5?   !     $& WindowMinimize=?5?   !   ?? 5?      -   5        $+ maximumButton??5?   !   $
??16,0q?5?   !   $" 	最大化??5?   !   ??5?   !     $& WindowMaximize=?5?   !   ?? 5?      -	   5        $+ closeButton??5?   !   , ? Cursor$
, Hand??5?   !   $" 关闭??5?   !   ??5?   !     $& Close=?5?   !   5?      5?      5?      ?? 5?      -
   5        - ??Name$- content??5?   !   (   "MyToDoDemo.Extension.RegionManager.   MainViewRegionName! 	 Prism.Regions.RegionManager/   
RegionName#/ Z. 62   5?      5?      5?      5?      