## blenderファイル
- 各種モデリングに使ったblenderファイル
- blender ver.2.91

### ファイル
- SGS_3D_blender
  - ClassRoom
    - 教室の3Dモデル
  - Gate
    - 学校正面の3Dモデル
    - 最初の入口に使った
  - ZenDo
    - 禅堂の3Dモデル

### 注意事項等
#### テクスチャについて
それぞれのフォルダの中のtexturesにまとまって入ってます
動かしたり消したりするとリンクが外れて教示されなくなったりするので注意

#### blenderからUnityに持っていく時
blenderの`File - Export - FBX`から出力したファイルをUnityにインポートすると使えるようになります

#### Unityにもっていったときにテクスチャが付かない場合
FBXファイルとテクスチャを同時に選択してインポートする

or

FBX出力時の画面右の`Path Mode`を`Copy`にして隣の`Embed Txtures`アイコンをONにする
↓
(Unity ver.2019以下の場合)UnityにImportした後に`Inspector - Materials - Textures - Extract Textures`でAsset内にテクスチャを書き出す
