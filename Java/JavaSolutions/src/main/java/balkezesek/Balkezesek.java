package balkezesek;

public class Balkezesek {

    private String name;
    private String firstPlay;
    private String lastPlay;
    private int weight;
    private int height;

    public Balkezesek(String name, String firstPlay, String lastPlay, int weight, int height) {
        this.name = name;
        this.firstPlay = firstPlay;
        this.lastPlay = lastPlay;
        this.weight = weight;
        this.height = height;
    }

    public String getName() {
        return name;
    }

    public String getFirstPlay() {
        return firstPlay;
    }

    public String getLastPlay() {
        return lastPlay;
    }

    public int getWeight() {
        return weight;
    }

    public int getHeight() {
        return height;
    }
}
