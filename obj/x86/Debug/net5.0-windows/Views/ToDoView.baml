   M S B A M L   `   `   `  ????E  AMyToDoDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:MyToDoDemo.Common.ConvertsMyToDoDemo.Common.Converts  5      3clr-namespace:MyToDoDemo.ViewsMyToDoDemo.Views  5          MyToDoDemo.Views.ToDoView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :count(clr-namespace:MyToDoDemo.Common.Converts     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      *localclr-namespace:MyToDoDemo.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5
        ? 	Resources  5      8   2MyToDoDemo.Common.Converts.Count2VisibilityConvert   countConvert??%   &	          5   
   6(   5      .??5      )  #MaterialDesignThemes.Wpf.DialogHost  .??5   
   )  #MaterialDesignThemes.Wpf.DrawerHost     IsRightDrawerOpen 6   ?? *IsRightDrawerOpen+   RightDrawerContent 5      ]? 5      $	??300??6   $??False??6(   .+?5      ??  ?? Padding$ 20,10q?5      $	??Top=?5      $??20(?5      $
??Bold"?5      $??添加待办??5      ?? 5      $??20q?5      $	??Top=?5       ?? Orientation$ 
Horizontal=?5      .+?5       ?? $??Center=?6$   $??	状态：??6?   ?? 5!       ?? SelectedIndex 6#   ?? *CurrentDto.Status+.@?5"      ?? .??6+   待办6/   ?? 5#      .??6+   	已完成60   5$      5%      ?? 5&      $??20q?5'      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入待办概要??5(      $	??Top=?5)      ??5*      ?? *CurrentDto.Title+?? 5+      $??30??5,      $??20q?5-      $ 请输入待办内容??5.      $	??Top=?5/       ?? TextWrapping$
 Wrap=?51      ??50      ?? *CurrentDto.Content+51      ?? 52      $
??20,0q?53      $??保存??55      $??添加到待办??56      $	??Top=?57      ??54      ?? *ExecuteCommand+57      58      .??5:      ?  ? RowDefinitions 5;      ?? 5<      $
??auto ?6$   ?? 5=      .+?5?      ?? $ 
Horizontal=?6   .+?5@      ?? $	??200??5A      $??30??5B      $??10,0,5,0q?5C      $ 查找待办事项...??5D      .  (MaterialDesignThemes.Wpf.TextFieldAssist	   HasClearButton$
	 True??5E      ??5F      ?? *
SearchText+
 ?? UpdateSourceTrigger$
 PropertyChanged=?.??6Z    J? InputBindings 5G      ?? 5H      
 ?? Key$ Enter??5I   !    ?? CommandParameter$ 查询??5K   !    ?? Command 5J   !   ?? *ExecuteCommand+5K   !   .??5L   1   5M      ?? 5N      $
??10,0q?5O      $??Center=?5P      $??筛选 ??5Q      ?? 5R       6   ?? *Status+.@?5S      ??  ?? 
IsSelected$
 True??6'   .??69   全部6=   ?? 5T      .??6'   待办6+   ?? 5U      .??6'   	已完成6,   5V      5W      ?? 5Y      $??5q?5Z      $??Right=?5[      $??新增??5]      $??+ 待办事项??5^      ??5\      ?? *ExecuteCommand+5^      ?? 5`      $??1??5a      $??Center=?5b      $??Center=?5c      y?5d      ?? *ToDoDtos.Count+ ?? 	Converter# [  .+?5e      ?? $	??100??6   $??/Sources/Images/wind.png??6(   ?? 5f      $
??0,10q?6    $3??-请添加待办事项，以便在此处显示??6.   5g      ?? 5h      $??1??5i      $??Center=?5j      ??5k      ?? *
ToDoDtos+??5l      ?? 5m      .R?5n      ? 5o      ??5q      ?? 5r      .R?5s      ? $	??200??5t   !   $	??180??5u   !   $??10q?5v   !   $??Center=?5w   !   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5x   "   +  %Microsoft.Xaml.Behaviors.EventTrigger  5y   &      	EventName$ MouseLeftButtonUp??65   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5z   *   2	  ,Microsoft.Xaml.Behaviors.InvokeCommandAction	   	  Command 6@   ?? *DataContext.SelectedCommand+ ?? RelativeSource ??  ?? Mode$ FindAncestor=? ?? AncestorType ItemsControl 	  CommandParameter 6?   ?? 5{   '    5}   "   ?? 5~   &   $
??auto ?64   ?? 5   &   .+?5?   "   ?? $??2??5?   %   
??? ? ? ?? CornerRadius$ 5??5?   %   ??5?   &   ?? 5?   *    ?? 
TargetType" ??60    ?? Triggers 5?   .   ?? 5?   2    ?? Binding 6>   ?? *Status+ ?? Value 06Y   .a?5?   6   ??  ?? Property ? ?? ?? Value
 ??p??6S   5?   3   ?? 5?   2    6>   ?? *Status+ 16Y   .a?5?   6   ??  ? ??
 ?"?"?6S   5?   3   5?   +   5?   #   ?? 5?   "   $??10q?6,   ??68   ?? *Title+'
  !MaterialDesignThemes.Wpf.PopupBox
  5?   "   $??Right=?6.     K? ZIndex$  1??6J   ! 
  PopupContent.! 5?   &   ?? $??删除??5?   )   ??5?   )   ?? *DataContext.DeleteCommand+ ?? $ FindAncestor=? ItemsControl??5?   )   ?? 5?   )   5?   #   ?? 5?   "   $??1??5?   %   $??
10,0,10,10q?5?   %   ??5?   %   ?? *	Content+?? 5?   "   $??2??6)   $
}?True??6:   .+?5?   &   ?? " ?? Left$	" 150??5?   )   
# ?? Top$# 10??5?   )   $	??100??5?   )   $	??100??5?   )   
???????$	 100??5?   )   $ J? Opacity$	$ 0.2Q?5?   )   ?? 5?   &   $	" 130??5?   )   $# 80??5?   )   $	??100??5?   )   $	??100??5?   )   
???????$	 100??5?   )   $	$ 0.2Q?5?   )   5?   #   5?      5?      5?      5?      5?      5?      5?      