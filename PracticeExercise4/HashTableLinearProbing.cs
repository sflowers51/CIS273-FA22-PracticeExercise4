using System;
using System.Data;
using System.Diagnostics;

namespace PracticeExercise4
{
    public class HashTableLinearProbing<K, V> : IHashTable<K, V>
    {

        private Bucket<K, V>[] buckets;
        private int initialCapacity = 16;


        public HashTableLinearProbing()
        {
            buckets = new Bucket<K, V>[initialCapacity];

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new Bucket<K, V>();
            }

        }

        private int count;
        private readonly double MAX_LOAD_FACTOR = 0.6;

        public int Count => count;

        public double LoadFactor => count / (double)buckets.Length;

        // O(1) - average case
        // O(n) - worst case
        public bool Add(K key, V value)
        {
            if (LoadFactor > MAX_LOAD_FACTOR)
            {
                Resize();
            }

            // find the hash
            int hash = Hash(key);

            // find the starting index
            int startingIndex = hash % buckets.Length;
            int bucketIndex = startingIndex;

            while (buckets[bucketIndex].State == BucketState.Full)
            {
                // if the key already exists, then update it.
                if (buckets[bucketIndex].Key.Equals(key))
                {
                    buckets[bucketIndex].Value = value;
                    return true;
                }


                bucketIndex = (bucketIndex + 1) % buckets.Length;

                if (bucketIndex == startingIndex)
                {
                    throw new OutOfMemoryException();
                }
            }

            // if the key doesn't exist, then add it.
            buckets[bucketIndex].Key = key;
            buckets[bucketIndex].Value = value;
            buckets[bucketIndex].State = BucketState.Full;
            count++;
            return false;

        }

        // O(1) - average case
        // O(n) - worst case
        public bool ContainsKey(K key)
        {
            var things = GetKeys();

            foreach(var thing in things)
            {
                if(thing.Equals(key))
                {
                    return true;
                }
            }

            return false;

        }

        // O(n) - average case
        // O(n) - worst case
        public bool ContainsValue(V value)
        {
            var things = GetValues();

            foreach (var thing in things)
            {
                if (thing.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        // O(1) - average case
        // O(n) - worst case
        public V Get(K key)
        {
            // compute the hash
            int hash = Hash(key);

            // compute the index
            int startingIndex = hash % buckets.Length;

            //find the list
            var bucketIndex = startingIndex;

            while (buckets[bucketIndex].State != BucketState.EmptySinceStart)
            {
                if (buckets[bucketIndex].Key.Equals(key) && buckets[bucketIndex].State == BucketState.Full)
                {
                    return buckets[bucketIndex].Value;
                }

                bucketIndex = (bucketIndex + 1) % buckets.Length;

                if (bucketIndex == startingIndex)
                {
                    throw new OutOfMemoryException();
                }
            }

            return default(V);

        }

        // O(n) - average case
        // O(n) - worst case
        public List<K> GetKeys()
        {
            List<K> keys = new List<K>();

            foreach(var bucket in buckets)
            {
                if(bucket.State == BucketState.Full)
                {
                    keys.Add(bucket.Key);

                }
            }

            return keys;
        }

        // O(n) - average case
        // O(n) - worst case
        public List<V> GetValues()
        {

            List<V> values = new List<V>();

            foreach (var bucket in buckets)
            {
                if (bucket.State == BucketState.Full)
                {
                    values.Add(bucket.Value);

                }
            }

            return values;
        }

        // O(1) - average case
        // O(n) - worst case
        public bool Remove(K key)
        {

            // find the hash
            int hash = Hash(key);

            // find the starting index
            int startingIndex = hash % buckets.Length;

            int bucketIndex = startingIndex;

            while (buckets[bucketIndex].State == BucketState.Full)
            {
                if (buckets[bucketIndex].Key.Equals(key))
                {
                    buckets[bucketIndex].Clear();
                    count--;
                    return true;
                }

                bucketIndex = (bucketIndex + 1) % buckets.Length;

                if (bucketIndex == startingIndex)
                {
                    throw new OutOfMemoryException();
                }

            }
        
            return false;

        }

        private void Resize()
        {
            var newBuckets = new Bucket<K, V>[2 * buckets.Length];
            var oldBuckets = buckets;

            buckets = newBuckets;
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new Bucket<K, V>();
            }

            count = 0;

            // rehash all the old/existing buckets into the new array/hashtable
            foreach (var bucket in oldBuckets)
            {
                if (bucket.State == BucketState.Full)
                {
                    Add(bucket.Key, bucket.Value);
                }
            }
        }


        private int Hash(K key)
        {
            int hash = key.GetHashCode();

            return hash < 0 ? -hash : hash;
        }
    }
}

