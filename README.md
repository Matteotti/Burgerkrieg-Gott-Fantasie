# Burgerkrieg-Gott-Fantasie
Course project of ZJU Computer Game Programming Design :)

## version 2022.11.12.2 latest edit: yyz

增加了点击地图块在UI上显示信息

补全了生成地图块和删除地图块的函数，但是由于依赖于HexToWorldPos函数，暂时还不能用，等HexToWorldPos函数写好后就OK了

## version 2022.11.12 latest edit: gtz

增加了几个简单的粒子系统（后续美工替换就行）

实现了动态更新粒子系统，选择元素时自动匹配。

在GridInventory加入了四种元素对应的效果引用（目前只有粒子效果）

修改了Inventory的元素列表使之符合策划案（现在有一个元素列表和一个各元素粒子列表，有一点屎）

在更新脚本加入了一个bool用来控制Update的开关（实在是黔驴技穷没办法了，只好麻烦下操作人员）。现在的操作是，打开shouleUpdate，编辑地图块，然后关闭。

## version 2022.11.12.1 latest edit: yyz

增加了相机

## version 2022.11.11 latest edit: gtz

小修了mesh的一些引用问题（更高效了废话少了）

增加了材质切换。目前只有一个默认材质。

## version 2022.11.10.2, latest edit: yyz   

今天把镜头移动给写了，把鼠标点击格子显示信息的框架搭出来了，我下午做一点UI，然后再写一下生成格子和销毁格子的函数  

地图这块需要讨论和完善的：      
    
需要做哪些元素反应？机制是什么呢？     
     
棋子站在格子上的时候地图块需要做些什么？传递元素？   
棋子与格子交互的时候需要做什么？特殊格子传递效果？   
这一部分好像需要与人物组对接      

UpdateCell函数也需要更改格子的特效与粒子系统，需要完善    

另外我们的格子排布方式改变了，所以WorldPosToHexPos和HexPosToWorldPos需要修改一下，因为我不知道是怎么排布的，所以可能得你来写一下这两个函数    
