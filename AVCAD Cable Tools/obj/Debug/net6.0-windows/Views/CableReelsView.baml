   M S B A M L   `   `   `  ????  AVCAD Cable Tools     AVCAD.Views.CableReelsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N? Title$  CableReelsView??5      .??5	      ]? .+?5
   
   ?  ? RowDefinitions 5      ?? 5      $
??0.1* ?6    60   ?? 5      $
??0.9* ?6    60   .+?5      ?? $??Center=?5      $
??Left=?5       ?? Orientation$ 
Horizontal=?5      $??0??5      .+?5      ?? $??Load SQLite database??5      $??10q?5      ??5      ?? *%#LoadSQLiteDatabaseCableReelsCommand+5      ?? 5      $??Create cable reel??5      $??10q?5      ??5      ?? *AddCableReelCommand+5      5      ?? 5       $??1??6   .+?5!      &   System.Windows.Controls.DataGrid  -   5          Name$ CableTypesDataGrid??5"      $	??500??5#         AutoGenerateColumns$ False??5$      $??10q?5&      ??5%      ?? *
CableReels+ ? 	Resources 5'      )  #System.Windows.Controls.DataGridRow ?? 
TargetType ?? Property ?? Value??%p   '        ?? 5(      "  6    .?5)      ??  ?@ 
IsSelected 5*   !   ?? *
IsSelected+5+      5,      	   Columns	 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id??6-      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.1* 6P      
IsReadOnly$
 True??6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ?? *Id+6q     5/      $

 Name??6-   $
 0.5* 6T   $
 True??6a    6;   ?? *Name+6u     50      $
 
Cable Type??6-   $
 0.2* 6_   $
 True??6l    6A   ?? *	CableType+6?     51      $
 Length??6-   $
 0.2* 6X   $
 True??6e    6=   ?? *Length+6y    ? ContextMenu 53      ?? 54      .@?55      m? $??Edit this Cable Reel??6'    m? Command 56   '   ?? *EditCableReelCommand+ m? CommandParameter 57   '   ?? *PlacementTarget.SelectedItem+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType" ??6?   m? 58      $??Delete this Cable Reel??59   !    5:   !   ?? *DeleteCableReelCommand+ 5;   !   ?? *PlacementTarget.SelectedItems+ ?? *FindAncestor+" ??6?   5<      5>      5?      5@      5B      5C      