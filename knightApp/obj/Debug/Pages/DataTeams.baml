   M S B A M L   `   `   `  ����D  @knightApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:knightApp.PagesknightApp.Pages  5          knightApp.Pages.DataTeams   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:knightApp.Pages     5      -   5          N� Title$  	DataTeams��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��40 �6   6*   �� 5      6   .+�5   
   � $��2��6      headerBackground#��[  5      6;   �� 5   
   $��2��6     
headerText#��[ 5      6:   �� 5   
   $��2��6   $��1��5      $��Center=�5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/Images/teams.png��6     ImageHeader#��[ 5      �� 5       $��Команды��6     
TBoxHeader#��[ 5!      6B   5"      5#      �� 5%   
   $��2��6   $��2��5&      $��Center=�5'      $��Center=�5(      .+�5)      �� $ 
Horizontal=�6   $��Right=�5*        AttributesCurrentEntity#��[ 5+      .+�5,      �� $"��Идентификатор: ��6   $��14(�5-      6,   �� 5.      -   5        $��TBoxId��5.        TBoxDataCurrentEntity#��[ 5/       �� 
IsReadOnly . 50   .   51      �� 53      $ 
Horizontal=�6   $��Right=�54      #��[ 55      .+�56      �� $��Название: ��6   $��14(�57      6,   �� 58      -   5        $��TBoxName��58      #��[ 59      6K   5:      �� 5<      $ 
Horizontal=�6   $��Right=�5=      #��[ 5>      .+�5?      �� $#��Состав команды: ��6   $��14(�5@      $��0 5 0 0q�5A      6/   �� 5B      -   5        $��ListAthletesInTeam��5C        ListBoxDataCurrentEntity#��[ 5B      5C   6   5D      �� 5F      $ 
Horizontal=�6   $��Right=�5G      #��[ 5H      .+�5I      �� $%��Номер трансфера: ��6   $��14(�5J      6,   �� 5K      -   5        $��CBoxTransferNumber��5K        CBoxDataCurrentEntity#��[ 5L        ComboBoxCurrententity#���  5M      6P   5N      5Q      �� 5S   
   -   5        $��ButtonPDFSportsman��5U      $��2��5S      $��Сохранить в PDF��5T       	 ButtonSections#��[	 5V       � 	Resources 5X       �� 
TargetType �� Property �� Value��%d   '��       �� 5Y      " ��6   .�5Z      ��  �@��CornerRadius$ 20��65   6B   5[      5\      5]      �� 5_   
   -   5        $��/Images/left-arrow.png��5_       
 	ArrowLeft#��[
 5`      $��0��5a      $��0��5b      5c      5d      5e      