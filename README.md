# Burgerkrieg-Gott-Fantasie
Course project of ZJU Computer Game Programming Design :)

## version 2022.11.10.2, latest edit: yyz   

今天把镜头移动给写了，把鼠标点击格子显示信息的框架搭出来了，我下午做一点UI，然后再写一下生成格子和销毁格子的函数  

地图这块需要讨论和完善的：      
    
需要做哪些元素反应？机制是什么呢？     
     
棋子站在格子上的时候地图块需要做些什么？传递元素？   
棋子与格子交互的时候需要做什么？特殊格子传递效果？   
这一部分好像需要与人物组对接      

UpdateCell函数也需要更改格子的特效与粒子系统，需要完善    

另外我们的格子排布方式改变了，所以WorldPosToHexPos和HexPosToWorldPos需要修改一下，因为我不知道是怎么排布的，所以可能得你来写一下这两个函数    

## version 2022.11.11 latest edit: gtz

小修了mesh的一些引用问题（更高效了废话少了）

增加了材质切换。目前只有一个默认材质。
