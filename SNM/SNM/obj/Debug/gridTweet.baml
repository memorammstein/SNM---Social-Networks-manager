   M S B A M L   `   `   `  ����  SNM    SNM.gridTweet   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��grdTweet��5   Y   $	��100��6   $	��425��6,   $��Stretch=�6;   $��0,5,0,5q�6i     � RowDefinitions  5      �� 5   
   $	��80* �6   �� 5	   
   $	��20* �6    � ColumnDefinitions 5      �� 5   
   $
��Auto �6   �� 5   
   $
��425* �6   .+�5      �� -   5        $��	stkAvatar��5       �� Orientation$ Vertical=�6"   $��5,0,5,0q�69   .+�5   
   �� -   5        $��avatar��5   E   $��Center=�6   $	��Top=�6-   $��50��6S   $��50��6_   $*��$/SNM;component/Iconos/twitter_64.png��6j   $	��0,5q�6�   6�   5      �� 5      $��1��6   $��1q�6!   $ Vertical=�6,   $��2��6C   $��Stretch=�6T   .+�5   
   �� -   5        $��stkScreenNames��5      $ 
Horizontal=�6+   $��25��6D   .+�5      �� -   5        $��tbkSreenName��5      $��13(�6,   $
��Bold"�6:   $��Bottom=�6L   NombreDeUsuario6�   �� 5      -   5        $��tbkFullName��5      $��11(�6+   $��Bottom=�69   
�������$��5,0,0,0q�6f   $��Arial)�6w   Nombre completo6�   �� 5      -   5        $��stkRetweeted��5   D   $ 
Horizontal=�6   $��15,0,0,0q�62   .+�5      �� -   5        $��avatarRetweeted��5      $��25��6/   $��25��6;   $*��$/SNM;component/Iconos/twitter_64.png��6F   6v   �� 5      -	   5        $��retweetedScreenName��5      $��5,0,2,0q�67   $��12(�6H   $��Bottom=�6V   
�������RT: UsuarioRetweet5      5      5      �� 5   
   -
   5        $��	stkStatus��5      $ Vertical=�6&   $��Stretch=�6=   .+�5      �� -   5        $��	tbkStatus��5       �� TextWrapping$
 Wrap=�6'   $��Arial)�6;   $
��Left=�6N   $��0,5,0,0q�6i    �� 
IsReadOnly . 
�������$��0q�5   ;   .��6O   ��5       �� 5!      .��5"   &   ��Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad mini5$      5%      5'      �� 5(      $��1��6   $��1��6!   $ 
Horizontal=�6.   $
��Left=�6G   $��Center=�6b   .+�5)   
   �� -   5        $��tbkDate��5)      $��10(�6#   2 nov6V   �� 5*   
   -   5        $��	tbkSource��5*      $��10(�6%   $��10,0,0,0q�63   social-networks-manager6~   5+      �� 5,      -   5        $��tweetActions��5,      $��1��6   $ 
Horizontal=�62   $��Center=�6K   .+�5-   
   �� -   5        $��	respuesta��5-      $��Iconos/reply.png��6!   $��16��5.      $��16��6      ImageButton#��[  6'   �� 5/   
   -   5        $��favorito��5/      $��Iconos/favorite.png��6    $��16��50      $��16��6   #��[  6'   �� 51   
   -   5        $��retweet��51      $��Iconos/retweet.png��6   $��16��52      $��16��6   #��[  6'   53      54      