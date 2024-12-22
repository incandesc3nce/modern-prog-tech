import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;

class MyString implements Comparable<MyString> {
    private String name;
    MyString() {}
    MyString(String n) {
        name = n;
    }

    public String getName() {
        return name;
    }

    private int countDigits() {
        int count = 0;
        for (char c : name.toCharArray()) {
            if (Character.isDigit(c)) {
                count++;
            }
        }
        return count;
    }

    public int compareTo(MyString other) {
        int thisDigitCount = countDigits();
        int otherDigitCount = other.countDigits();

        if (thisDigitCount == 2 && otherDigitCount != 2) {
            return -1;
        } else if (thisDigitCount != 2 && otherDigitCount == 2) {
            return 1;
        } else if (thisDigitCount == 2 && otherDigitCount == 2) {
            return this.name.compareTo(other.name);
        }

        return other.name.compareTo(this.name);
    }
}

public class Main {
    public static void main(String[] args) {
        ArrayList<MyString> a = new ArrayList<>();
        File file = new File("src/input.txt");
        try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
            String line;
            while ((line = reader.readLine()) != null) {
                a.add(new MyString(line));
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        System.out.println("Коллекция до сортировки:");
        Iterator<MyString> iterator = a.iterator();
        while (iterator.hasNext()) {
            System.out.print(iterator.next().getName() + " ");
        }

        Collections.sort(a);

        System.out.println("\nКоллекция после сортировки:");
        iterator = a.iterator();
        while (iterator.hasNext()) {
            System.out.print(iterator.next().getName() + " ");
        }
    }
}
