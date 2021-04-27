## Unityファイル
- clusterのワールド制作に必要なUnityファイル
- Unity **2019.4.11f1** (←[後述](https://github.com/yokenkn/SGS_3D/new/master/SGS_3D_Unity#unity%E3%81%AE%E3%83%90%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%B3%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6))
- Cluster Creator Kit ver.1.12.2

### 追記
Cluster Creator Kitがアップデートされ、ver.1.12.3になり、Unityの推奨バージョンが2019.4.22f1に変更されました(2021/4/27)

### ファイル
- SGS_3D_Unity(UnityプロジェクトのRoot)
  - Asset
    - ClusterVR
      - cluster Creator Kitのサンプル
    - Materials
    　- マテリアルたち
    - Models
      - blenderから出力したファイル

### 注意事項等
#### Unityのバージョンについて
[Unityの導入 - Cluster Creator Kit ドキュメント](https://clustervr.gitbook.io/creatorkit/installation/install-unity)

↑のサイトから対応バージョンをインストールして使う

UnityHubからではなく`Unity - Download Archive`からでないとインストールできないバージョンの場合もあるので注意

バージョンが違うとアップロードできなかったり正常に動作しないことがあるので注意

#### Cluster Creator Kitの導入、アップデートについて
[Creator Kitの導入 - Cluster Creator Kit ドキュメント](https://clustervr.gitbook.io/creatorkit/installation/install-creatorkit)

[Creator Kitのアップデート - Cluster Creator Kit ドキュメント](https://clustervr.gitbook.io/creatorkit/installation/update-creatorkit)

SGS_3D_Unityにはすでに導入済み

公式ドキュメントにはGitHubのリポジトリのダウンロードをして導入しているが、
PCにGitがインストールされていれば`Window > Package Manager > + > Add package from git URL`から
GitHubのリンクで導入、アップデートできるのでお勧め

また、[サンプルプロジェクト - Cluster Creator Kit ドキュメント](https://clustervr.gitbook.io/creatorkit/download/sample-project)
から導入済みのプロジェクトをダウンロードできるので新しくプロジェクトを作るならこの方法がおすすめ

#### 文字とかを置く場合
Unityで文字を置くとき、Canvasを使うと簡単だが、Canvasの中に`UI`メニュー内以外のオブジェクトを置くと表示が乱れたりするので注意

↓

canvasの中に置く文字の背景は`3D Object > Cube`ではなく`UI > Image`or`UI > Raw Image`を使うなど

### 参考リンク

主にClusterについて

#### Cluster Creator Kit ドキュメント
[Cluster Creator Kit ドキュメント](https://clustervr.gitbook.io/creatorkit/)

公式ドキュメント　Creator Kitの動作やエラーについてはここを参考に

#### Cluster Creators Guide
[Cluster Creators Guide](https://creator.cluster.mu/)

公式のワールド制作のチュートリアル

初めてワールドを作る人はここの手順で一回何か作ってみてもいいかも
