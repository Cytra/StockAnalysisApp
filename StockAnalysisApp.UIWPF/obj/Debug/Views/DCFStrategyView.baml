   M S B A M L   `   `   `  ����Q  MStockAnalysisApp.UIWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:StockAnalysisApp.UIWPF.ViewsStockAnalysisApp.UIWPF.Views  5   	   2    ,StockAnalysisApp.UIWPF.Views.DCFStrategyView   5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null9Window,http://metro.mahapps.com/winfx/xaml/controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:StockAnalysisApp.UIWPF.Views     5   	     � Title$  DCFStrategyView��5
   	   $	��800��6!   $	��600��6.    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   6,   �� 5      $	��200 �6   6-   �� 5      $��10 �6   6,   �� 5      $��* �6   6+   �� 5      $��10 �6   6,    � RowDefinitions 5   
   �� 5      $��10 �6   6*   �� 5      $��30 �6   6*   �� 5      $��10 �6   6*   �� 5      $��30 �6   6*   �� 5      $��10 �6   6*   �� 5      $��30 �6   6*   �� 5      $��10 �6   6*   �� 5      $��* �6   6)   �� 5      $��10 �6   6*   .+�5!   
   �� $��1��5"      $��1��5#      $��3��5$      ��5%      �� *	GetNewDCF+.��5&      
GET DATA6   �� 5'   
   $��3��6   $��1��5(      .��6    Stock Ticker6.   �� 5*   
   $��3��6   $��3��5+      ��5,      �� *StockTicker+ �� UpdateSourceTrigger$ PropertyChanged=�6V   �� 5.   
   $��5��6   $��1��5/      .��6    Date6&   �� 51   
   $��5��52      $��3��53      ��54      �� *
DateList+ �� StringFormat$ 
yyyy-MM-dd�� �� SelectedValue 55      �� *SelectedDate+56      )  #MahApps.Metro.Controls.ProgressRing  58   
   $��7��59      $��1��5:      $��3��5;         IsActive 5<      �� *
IsActive+&   System.Windows.Controls.DataGrid  5>   
   $��7��5@      $��1��5A      $��3��5B         AutoGenerateColumns .  y�5>      �� *DataGridVisibility+��5?      �� *Stocks+	   Columns	 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Symbol��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Symbol+6P     5G      $

 Date��6%   $ * 6e    63   �� *Date+$ 
yyyy-MM-dd��6e     5H      $
 Price��6%   $ * 6r    64   �� *Dcf.StockPrice+$ 
{0:#,#.00}��6r     5I      $	
 DCF��6%   $ * 6i    62   �� *	Dcf.DCF+$ 
{0:#,#.00}��6i     5J      $

 Diff��6%   $ * 6k    63   �� *
Dcf.Diff+$ 
{0:#,#.00}��6k     5K      $
 Score��6%   $ * 6Z    64   �� *StockRating.Score+6Z   5M      5N      5O      