   M S B A M L   `   `   `  ����G  CCourseClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CourseClientCourseClient  5   	       CourseClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CourseClient     5   	   -   5          �Name$  MainWindow1��5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � Title$ 
MainWindow��5
   	   $	��515��6   $	��668��6)   
������  � 	Resources 5         	TileBrush j� TileMode j� ViewportUnits �� ImageSource �� Opacity��%�   &	        �� 5   
   $ FlipX=�6'   $ RelativeToBoundingBox=�68   $1 +C:\Users\Adm\source\repos\course\green0.png��5      $ 1Q�6Q   6_   5      	 J� CommandBindings	 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
   Command$	
 New��5      5      .��5      � #��[  6    J� RenderTransformOrigin$ 0.5,0.5&�6?    � RowDefinitions 5   
   �� 5      $��95 �6   �� 5      �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6    � ColumnDefinitions 5!   
   �� 5"      $��95 �6   �� 5#      �� 5$      $��95 �6   .+�5'   
   �� -   5         ��Name$ SendBtn��5'      $
��Send��6"   $��Center=�61   $��
100,15,0,0q�6N   $	��Top=�6b   $	��216��6z   $ 0.849,-0.009&�6�   {�.  $��20��6�   $��3��6�   $��1��6�   �� 5(   
   -   5        $ Connect_btn��5(      $��Connect��6&   $
��Left=�68   $��	50,15,0,0q�6S   $	��Top=�6f   $	��102��6~   $	��New��6�   $��20��6�   $��3��6�   $��1��6�   �� 5)   
   -   5         ��Name$ Msgbox��5)      $��Center=�6"   $��23��6?   $��0,15,0,0q�6K    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��497��6�   $��2��6�   $��1��6�   �� 5*   
   -   5         ��Name$
 chat��5*      $��0,0,0,0q�6$   $��Center=�65   $ 0.5,0.5&�6T   $��1��6t   $��1��6�   z�5+      V� 5,      .~�5-      �� �� 5.      �� 5/       �� Angle$
 0.05Q�6&   T� 50      51      . �53      /� .T�54      J� .*�6   .*�55      �� $� ��6   56      57      58      �� 59   
   -   5        $
��Exit��59      $��1��6    $
��Left=�60   $��
347,65,0,0q�6K   $	��Top=�6_   $��77��6w   6�   5;      5<      