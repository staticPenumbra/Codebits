   M S B A M L   `   `   `  ����   OlsaLevelEditor1.0!    OlsaLevelEditor1._0.Window1   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml      � Title$  Window1��$	��715��$	��828��$��4q�
�������
�������
�����_�.��� .+�o� -   $��menuTop��$��28��$	��Top=�
���OO/�
�������
����� �.@�m� -   $��menuFile��
���OO/�$��1q�
���   �$
��File��.@�m� -   $��menuFileNew��$��New Map��
�����_�m� -   $��menuFileEdit��$
��Edit��
�����_�m� -   $��menuFileSave��$��menuFileSave��
�����_�m� -   $��menuFileSaveAs��$��Save As��
�����_�m� -   $��menuFileImport��$��Import��
�����_�m� -   $��menuFileExit��
�����_�$
��Exit��m� -	   $��menuEdit��
���   �$
��Edit��
���OO/�.@�m� -
   $��menuEditUndo��$
��Undo��
�����_�m� -   $��menuEditRedo��$
��Redo��
�����_�m� -   $��menuEditLayers��$��Layers��
�����_�m� -   $��menuEditPlayers��$��Players��
�����_�m� -   $��menuEditMapObjects��$��Map Objects��
�����_�m� -   $��menuEditResourceFile��$��Resource Files��
�����_�m� -   $��menuEditScripts��$��Scripts��
�����_�m� -   $��menuEditSounds��$��Sounds��
�����_�m� -   $��menuEditMapOptions��$��Map Options��
�����_�m� -   $��menuEditConfig��$��Level Editor Config��
�����_�m� -   $��menuView��$��View ��
���   �
������ 
���OO/�.@�m� -   $��menuViewFullScreen��
�����_�$��Map Full Screen��m� -   $��menuHelp��
���OO/�
���   �$
��Help��.@�m� -   $��menuHelpContents��$��Help Contents��
�����_�
���   �m� -   $��menuHelpAbout��$��About��
�����_��� -   $��
statusBar1��$��26��$��Bottom=�.@��� -   $��	statusBar��
�����w�$��2q�
������� �� ContentStringFormat$  ��
�������c� -   $��toolBar��$��38��$��0,28,0,0q�$	��Top=�
������ 
���OO/�$��1q��� -   $��tabControl1��$
��Left=�$��
0,68,0,187q�$	��204��
�������
���OO/�$��2q�.@��� -   $��tabMenuResources��$��	Resources���� -   $��tabMenuLayers��$��Layers���� -   $��tabMenuScripts��$��Scripts���� -    $��tabMenuProperties��$��Propterties���� -!   $��
zoomSlider��$��26��$��Right=�$��0,0,45,0q�$��Bottom=�$��82�� �� TickFrequency$ 4Q� �� TickPlacement$ BottomRight=�
���OO/�$��1q� � Maximum$ 8Q� � Minimum$ 1Q� � Value$ 4Q��� -"   $��zoomPositionLabel��$��25��$��Right=�$��0,0,0,1q�$��Bottom=�$��41��$��1q�
���OO/�$��LeftToRight=�.��100%�� -#   $��statusBarZoomLabel��$��26��$��Right=�$��	0,0,132,0q�$��Bottom=�$��44��$��RightToLeft=�
���OO/�$��1q�.��Zoom:�� -$   $��statusBarMapCoord��$��26��$��Right=�$��	0,0,192,0q�$��Bottom=�$	��129��
���OO/�$��1q�.��X/Y: � -%   $��frameMiniMap��$	��162��$
��Left=�$��0,0,0,26q�$��Bottom=�$	��204��$��2q�
���OO/� � -&   $��frameMap��
���OO/�$��2q�$��206,68,0,26q��� -'   $��selectButton��$��30��$
��Left=�$��	15,32,0,0q�$	��Top=�$��33��
������ 
���   �
���OO/��� -(   $��	newButton��
������ 
���OO/�
���   �$��30��$
��Left=�$��	52,32,0,0q�$	��Top=�$��33���� -)   $��
saveButton��
������ 
���OO/�
���   �$��30��$
��Left=�$��	89,32,0,0q�$	��Top=�$��33���� -*   $��mapOptionsButton��
������ 
���OO/�
���   �$��30��$
��Left=�$��
126,32,0,0q�$	��Top=�$��33���� -+   $��listBox1��$��29��$��
253,33,0,0q�$	��Top=�
������ 
���   �
���OO/�$��12(�$
��Left=�$��83��$��Center=� �� SelectionMode$ Single=�$��Center=�.@��� -,   $��playerSelectList��$��Center=�$��Center=�$��3,3,0,0q�.��
Player 1�� --   $��toolbarPlayerSelect2��$��Center=�$��Center=�$��3,3,0,0q�.��
Player 2�� -.   $��toolbarPlayerSelect3��$��Center=�$��Center=�$��3,3,0,0q�.��
Player 3�� -/   $��toolbarPlayerSelect4��$��Center=�$��Center=�$��3,3,0,0q�.��
Player 4�� -0   $��toolbarPlayerSelect5��$��Center=�$��Center=�$��3,3,0,0q�.��
Player 5�� -1   $��toolbarPlayerSelect6��$��Center=�$��Center=�$��3,3,0,0q�.��
Player 6�� -2   $��toolbarPlayerSelect7��$��Center=�$��Center=�$��3,3,0,0q�.��
Player 7�� -3   $��toolbarPlayerSelect8��$��Center=�$��Center=�$��3,3,0,0q�.��
Player 8�� -4   $��toolbarPlayerLabel��
���OO/�$��1q�$��LeftToRight=�$��29��$
��Left=�$��
168,33,0,0q�$	��Top=�$��82��$��Center=�$��Center=�.��Player Select:�� -5   $��statusBarInfoLabel��
���OO/�$��1q�$��LeftToRight=�$��26��$��	1,0,347,1q�$��Bottom=�.��Info�� -6   $��showGridButton��
������ 
���OO/�
���   �$��30��$
��Left=�$��
344,32,0,0q�$	��Top=�$��33���� -7   $��mirrorMapButton��
������ 
���OO/�
���   �$��30��$��383,32,382,0q�$	��Top=�