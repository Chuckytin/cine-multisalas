   M S B A M L   `   `   `  ����I  ECineMultisalas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CineMultisalas.HelpersCineMultisalas.Helpers  5   	   +    %CineMultisalas.Views.ReservationsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   8helpers$clr-namespace:CineMultisalas.Helpers     5   	     � Title$  Reservas��5   	   $	��450��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5      +   %CineMultisalas.Helpers.SeatsConverter   SeatsConverter��%   &	          5	   
   6!   5
      .��5      � $��10q�6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  $��0,0,0,50q�5         
IsReadOnly .    	RowHeight$ 40Q�5      ��5      �� *Reservations+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Sala��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 63   �� *
CinemaName+6R     5      $ Asientos Reservados��6%   $ * 5      	 5      �� *SelectedSeats+
 �� 	Converter#
 [     ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6=   5      5      5       5!      5"      