#include <iostream>
#include <string>
#include <cctype>

// Encrypts a single character using Caesar shift + keyword-based shift
char encrypt_char(char c, int shift, char key_c) {
    if (std::isalpha(static_cast<unsigned char>(c))) {
        char base = std::islower(c) ? 'a' : 'A';
        int key_shift = (std::tolower(key_c) - 'a') % 26;
        int total_shift = (c - base + shift + key_shift) % 26;
        return static_cast<char>(base + total_shift);
    }
    return c; // Non alphabetic characters unchanged
}

// Decrypts a single character using Caesar shift + keyword-based shift
char decrypt_char(char c, int shift, char key_c) {
    if (std::isalpha(static_cast<unsigned char>(c))) {
        char base = std::islower(c) ? 'a' : 'A';
        int key_shift = (std::tolower(key_c) - 'a') % 26;
        int total_shift = (c - base - shift - key_shift) % 26;
        if (total_shift < 0) total_shift += 26;
        return static_cast<char>(base + total_shift);
    }
    return c;
}

// Encrypts the entire text sequentially
std::string encrypt(const std::string &text, int shift, const std::string &keyword) {
    std::string result;
    result.reserve(text.size());
    for (size_t i = 0; i < text.size(); ++i) {
        char key_c = keyword[i % keyword.size()];
        result.push_back(encrypt_char(text[i], shift, key_c));
    }
    return result;
}

// Decrypts the entire text sequentially
std::string decrypt(const std::string &cipher, int shift, const std::string &keyword) {
    std::string result;
    result.reserve(cipher.size());
    for (size_t i = 0; i < cipher.size(); ++i) {
        char key_c = keyword[i % keyword.size()];
        result.push_back(decrypt_char(cipher[i], shift, key_c));
    }
    return result;
}

int main() {
    std::string text;
    std::string keyword;
    int shift;

    std::cout << "Enter text: ";
    std::getline(std::cin, text);

    std::cout << "Enter shift amount: ";
    std::cin >> shift;
    std::cin.ignore();

    std::cout << "Enter keyword: ";
    std::getline(std::cin, keyword);

    std::string encrypted = encrypt(text, shift, keyword);
    std::string decrypted = decrypt(encrypted, shift, keyword);

    std::cout << "Encrypted: " << encrypted << '\n';
    std::cout << "Decrypted: " << decrypted << '\n';

    return 0;
}

