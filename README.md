# RPG

未完成のプロジェクトの簡単な説明をいたします。

このプロジェクトのデータはすべてJsonに管理し、入力している点を先に説明します。
# Actor
基本的にBaseObjectの機能を継承して機能が定義されます。オブジェクト間の関係を定義して、オブジェクトを生成する機能のコードです。

# AI
基本的にNavMeshAgentを利用して作った状況に応じてアニメーション動作をロードします。 NormalAI scriptで実際にプレイヤーをナビゲートして追跡して、自分が持っている射程距離に応じてプレイヤーを攻撃するか否かを判断することでした。スキルに関するスクリプトは後述します。


# Board
HP Bar、Damage Barを示すためのコードです。 BoardまたBaseクラスを作成し、その後HP Bar、Damage Barを実装しました。

# Character
キャラクターの基本的なステータスの設定を実装します。 CharacterStatusDataは、実際のキャラクターにデータを適用させるクラスであり、CharacterTemplateDataはJsonデータを使用するための処理です。

# StatusData
これらのデータのコピーとの増加、減少、設定と削除を担当し、これらのデータは、Dictionaryに格納して管理します。

# BaseObject
すべてのオブジェクトのgameObjectとtransformを管理します。すべてのオブジェクトは、BaseObjectを継承し実装されます。

# ENUM,ConstValue
コードが乱雑になることを懸念して一元別に管理します。

# JoyStick
文字通りJoyStickを実装したものです。

# Item
Itemの情報もJsonに管理し、入力しているので、ジェイソンに保存されている情報に従って情報が出力されるように実装されました。

# ItemInfo
ItemInfoでジェイソンに保存されている情報を取得されItemInstanceでアイテム情報のgetとsetの実装たものです。

# manager
各自が担当するオブジェクトを管理します。すべてのマネージャーは、Singletonを継承して、データをDictionaryに保存したり、プレハブを初期化し、ロードして削除します。

# Skill
SkillとStageの場合も、itemと同様Jsonに管理し、情報を入力します。

# UI
UIに関するすべてがあります.LobbyManagerとLogoManagerはLobbyとlogoをロードしinventory、item、loadingbarなどを実装します。
