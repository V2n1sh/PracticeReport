   M S B A M L   `   `   `  ����D  @knightApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:knightApp.PagesknightApp.Pages  5      %    knightApp.Pages.DataTournaments   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:knightApp.Pages     5      -   5          N� Title$  DataTournaments��5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��40 �6   6*   �� 5      6   �� 5      $��40 �6   6*   .+�5   
   � $��2��6      headerBackground#��[  5      6;   �� 5   
   $��2��6     
headerText#��[ 5      6:   �� 5   
   $��2��6   $��1��5      $��Center=�5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��/Images/tournaments.png��6     ImageHeader#��[ 5       �� 5!      $��Турниры��6     
TBoxHeader#��[ 5"      6B   5#      5$      �� 5&   
   $��2��6   $��2��5'      $��Center=�5(      $��Center=�5)      .+�5*      �� $ 
Horizontal=�6   $��Right=�5+        AttributesCurrentEntity#��[ 5,      .+�5-      �� $"��Идентификатор: ��6   $��14(�5.      6,   �� 5/      -   5        $��TBoxId��5/       �� 
IsReadOnly .   TBoxDataCurrentEntity#��[ 51      6K   52      �� 54      $ 
Horizontal=�6   $��Right=�55      #��[ 56      .+�57      �� $��Название: ��6   $��14(�58      6,   �� 59      -   5        $��TBoxName��59      #��[ 5:      6K   5;      �� 5=      $ 
Horizontal=�6   $��Right=�5>      #��[ 5?      .+�5@      �� $��Город: ��6   $��14(�5A      6,   �� 5B      -   5        $��CBoxCity��5B        ComboBoxCurrententity#���  5C        CBoxDataCurrentEntity#��[ 5D      6L   5E      �� 5G      $ 
Horizontal=�6   $��Right=�5H      #��[ 5I      .+�5J      �� $��Улица: ��6   $��14(�5K      6,   �� 5L      -   5        $��
CBoxStreet��5L      #���  5M      #��[ 5N      6L   5O      �� 5Q      $ 
Horizontal=�6   $��Right=�5R      #��[ 5S      .+�5T      �� $��Номер дома: ��6   $��14(�5U      6,   �� 5V      -   5        $��TBoxHomeNumber��5V      #��[ 5W      6L   5X      �� 5Z      $ 
Horizontal=�6   $��Right=�5[      #��[ 5\      .+�5]      �� $��Начало: ��6   $��14(�5^      6,   �� 5_      -   5        $��	TBoxStart��5_      #��[ 5`      6K   5a      �� 5c      $ 
Horizontal=�6   $��Right=�5d      #��[ 5e      .+�5f      �� $��Конец: ��6   $��14(�5g      6,   �� 5h      -   5        $��TBoxEnd��5h      #��[ 5i      6K   5j      �� 5l      $ 
Horizontal=�6   $��Right=�5m      #��[ 5n      .+�5o      �� $��Вид Спорта: ��6   $��14(�5p      6,   �� 5q      -	   5        $��CBoxSortOfSport��5q      #���  5r      #��[ 5s      6L   5t      5u      �� 5w   
   $��3��6   $��2��5x      $��Center=�5y      $ 
Horizontal=�5z      .+�5{      �� .+�5|      �� -
   5        $��ButtonDeleteTournament��5      $��4��5|      $��2��5}      $��Удалить��5~        ButtonSections#��[ 5�      $��0 0 10 0q�5�       � 	Resources 5�       �� 
TargetType �� Property �� Value��%d   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 20��6=   6J   5�      5�      5�      5�      �� 5�      .+�5�      �� -   5        $��ButtonPDFSportsman��5�      $��4��5�      $��Сохранить в PDF��5�      #��[ 5�       5�      ��%d   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 20��6=   6J   5�      5�      5�      5�      5�      �� 5�   
   -   5        $��/Images/left-arrow.png��5�       	 	ArrowLeft#��[	 5�      $��0��5�      $��0��5�      5�      5�      5�      