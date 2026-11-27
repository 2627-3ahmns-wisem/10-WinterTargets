# Frosty Targets – 3AHMNS

Unity-Version: **6000.3.24f1**. Projekt: Frosty Targets.

## Projekt öffnen
1. Unity Hub öffnen, **Add project from disk** wählen und diesen Ordner auswählen.
2. Unity **6000.3.24f1** verwenden und den ersten Paketimport abwarten.
3. Szene `Assets/MyGame/Scenes/ShootingScene.unity` öffnen, **Play** drücken.
4. `Assets/MyGame/Scripts/GameManager.cs` und `Target.cs` untersuchen.

## Hinweis bei `UnityEngine.UI` / `Text`-Fehlern
Das Paket **Unity UI (uGUI)** ist unter `Packages/manifest.json` als `com.unity.ugui` eingetragen. Falls trotzdem CS0234 oder CS0246 erscheint: `Window > Package Management > Package Manager` öffnen und unter **In Project** prüfen, ob Unity UI geladen ist. Im Paketmanager **Refresh/Resolve** ausführen; gegebenenfalls Unity schließen und den Ordner `Library` löschen, dann erneut öffnen. Nicht die `using UnityEngine.UI`-Zeile entfernen: sie wird für die vorhandene Punkteanzeige gebraucht.

## Wie das Spiel funktioniert

Ziel ist es, zehn Zielscheiben anzuklicken, bevor sie verschwinden.

## Ablauf
Erzeugen: Jede Sekunde erscheint eine neue Zielscheibe an einer zufälligen Stelle.
Anklicken: Klickt man eine Zielscheibe an, verschwindet sie sofort.
Punkte: Jeder Treffer gibt einen Punkt. Die Zahl oben im Bild zeigt den Punktestand.
Spielende: Bei 10 Punkten erscheint „GEWONNEN“ und es kommen keine neuen Zielscheiben mehr.

## Die wichtigsten Methoden
Start in GameManager.cs startet beim Spielbeginn. Die Methode sorgt dafür, dass Spawn() nach 1 Sekunde und danach jede Sekunde aufgerufen wird (InvokeRepeating).
Update in GameManager.cs läuft in jedem Frame. Die Methode stoppt das Erzeugen, sobald gewonnen ist. Außerdem spielt sie bei jedem Linksklick einen Schuss-Sound ab.
Spawn in GameManager.cs erzeugt eine neue Zielscheibe als Kopie des Prefabs und setzt sie an eine zufällige Position.
OnMouseDown in Target.cs wird aufgerufen, wenn man auf die Zielscheibe klickt. Die Methode gibt dem GameManager einen Punkt und löscht die Zielscheibe.

##Bereits vorhandene Funktionen
Zufallsposition: Spawn() wählt X zwischen -365 und 365 und Y zwischen -202 und 202. Die Zielscheibe wird ein child von parentOfTargets und bekommt ihre Position über localPosition.
Punkteanzeige: IncrementScore() zählt score um 1 hoch und schreibt den Wert in das Textfeld scoreText.
Siegbedingung: Ab score >= 10 wird win auf true gesetzt und das Bild winSprite eingeblendet. Update() beendet dann das Erzeugen mit CancelInvoke("Spawn").
Selbstzerstörung: Jede Zielscheibe verschwindet nach 2 Sekunden von selbst, wenn sie nicht getroffen wird.

##Meine Ideen
Ich will einen Timer hinzufügen damit man auch verlieren kann. Nach dem Sieg soll ein Neustart-Knopf erscheinen. Mit steigendem Punktestand soll das Spiel schneller werden.
## Unterricht
Das vorhandene Spawning, der Score und der Sieg bei zehn Treffern sind **Ausgangscode**. Schüler:innen erweitern diese Mechaniken anhand der GitHub-Issues. Der Erstimport ist eine Ausgangsversion; keine Aufgaben sind vorweg implementiert.
