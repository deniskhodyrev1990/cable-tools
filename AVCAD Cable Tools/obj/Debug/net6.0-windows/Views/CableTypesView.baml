   M S B A M L   `   `   `  ????  AVCAD Cable Tools     AVCAD.Views.CableTypesView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N? Title$  CableTypesView??5      .??5      ]? .+?5	   
   ?  ? RowDefinitions 5
      ?? 5      $
??0.1* ?6    60   ?? 5      $
??0.9* ?6    60   .+?5      ??  ?? Orientation$ 
Horizontal=?5      $??0??5      $??Center=?5      $
??Left=?5      .+?5      ?? $??Load SQLite database??5      $??10q?5       ? Cursor$
 Hand??6!   ??5      ?? *$"LoadSQLiteDatabaseCableTypeCommand+5      ?? 5      $??Create cable type??5      $??10q?5      ??5      ?? *AddCableTypeCommand+5      5      ?? 5      $??1??6   .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ CableTypesDataGrid??5       $	??500??5!         AutoGenerateColumns$ False??5"      $??10q?5$      ??5#      ?? *
CableTypes+ ? 	Resources 5%      )  #System.Windows.Controls.DataGridRow ?? 
TargetType ?? Property	 ?? Value??%p   '        ?? 5&      "  6    .?5'      ??  ?@ 
IsSelected	 5(   !   ?? *
IsSelected+5)      5*      
   Columns
 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.1* 6P      
IsReadOnly$
 True??6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ?? *Id+6q     5-      $ 
Cable Type??6-   $
 0.5* 6Z   $
 True??6g    6A   ?? *Type+6{     5/      $ 
Max Length??6-   $
 0.2* 6_   $
 True??6l    6A   ?? *	MaxLength+6?    ? ContextMenu 51      ?? 52      .@?53      m? $??Edit this Cable Type??6'    m? Command 54   '   ?? *EditCableTypeCommand+ m? CommandParameter 55   '   ?? *PlacementTarget.SelectedItem+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType" ??6?   m? 56      $??Delete this Cable Type??6'    57   '   ?? *DeleteCableTypeCommand+ 58   '   ?? *PlacementTarget.SelectedItems+ ?? *FindAncestor+" ??6?   59      5;      5<      5=      5?      5@      